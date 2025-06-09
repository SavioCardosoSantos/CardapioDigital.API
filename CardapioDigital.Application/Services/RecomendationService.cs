using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.DTOs.CardapioCliente;
using CardapioDigital.Application.DTOs.ChatGPT;
using CardapioDigital.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CardapioDigital.Application.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IMapper _mapper;
        private readonly string? _apiKey;
        private readonly HttpClient _client;

        public RecommendationService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<IEnumerable<string>> GerarTags(string nomeItem, string descricaoItem)
        {
            try
            {
                var promptGeracaoTag = MontarPromptGeracaoTag();
                var dadosItem = new StringBuilder();
                dadosItem.AppendLine($"Nome: {nomeItem}");
                dadosItem.AppendLine($"Descrição: {descricaoItem}");

                var content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model = "gpt-4.1",
                        messages = new[] {
                        new { role = "system", content = promptGeracaoTag },
                        new { role = "user", content = dadosItem.ToString() }
                        }
                    }),
                    Encoding.UTF8, "application/json"
                );

                var response = await _client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                var chatGptResponse = JsonConvert.DeserializeObject<ChatGptResponse>(responseBody);

                if (chatGptResponse == null)
                    throw new Exception();

                return chatGptResponse.Choices.First().Message.Content.Split(";").ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ocorreu uma falha ao gerar as tags para o item.\nErro: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ItemCardapioDTO>> MontarAbaRecomendados(
            IEnumerable<ItemCardapioDTO> itensCardapio,
            IEnumerable<string> tagsPedidosAnteriores,
            IEnumerable<string> tagsOnboarding,
            IEnumerable<string> restricoesAlimentares)
        {
            try
            {
                Dictionary<string, int> tagsDic;
                ContarTags(tagsPedidosAnteriores, tagsOnboarding, out tagsDic);

                IEnumerable<ItemCardapioRanqueado> itensRanqueados;
                RanquearItens(itensCardapio, tagsDic, out itensRanqueados);

                string promptRecomendacaoGPT;
                MontarPromptRecomendacaoGPT(
                    itensRanqueados.Take(15),
                    tagsDic.Take(15).ToDictionary(),
                    restricoesAlimentares,
                    5,
                    out promptRecomendacaoGPT);

                var content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model = "gpt-4.1",
                        messages = new[] {
                        new { role = "system", content = "Você é um assistente que recomenda itens de um cardápio com base nas preferências e restrições do usuário." },
                        new { role = "user", content = promptRecomendacaoGPT }
                        }
                    }),
                    Encoding.UTF8, "application/json"
                );

                var response = await _client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                var chatGptResponse = JsonConvert.DeserializeObject<ChatGptResponse>(responseBody);
                var responseContent = chatGptResponse.Choices.First().Message.Content;

                var itensIdsRecomendados = responseContent.Split('[')[1].Split(']')[0].Split(';').ToList();
                var itensRecomendados = new List<ItemCardapioDTO>();
                foreach(var itemId in itensIdsRecomendados)
                {
                    var itemDto = itensCardapio.First(x => x.Id == int.Parse(itemId));
                    if (itemDto != null)
                        itensRecomendados.Add(itemDto);
                }

                return itensRecomendados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu uma falha ao montar a aba de itens recomendados.\nErro: {ex.Message}");
            }
        }


        #region Métodos privados da classe
        private static void ContarTags(
            IEnumerable<string> tagsPedidosAnteriores,
            IEnumerable<string> tagsOnboarding,
            out Dictionary<string, int> tagsDic)
        {
            tagsDic = new Dictionary<string, int>();
            foreach (var texto in tagsPedidosAnteriores)
            {
                if (tagsDic.ContainsKey(texto))
                    tagsDic[texto] += 1;
                else
                    tagsDic[texto] = 1;
            }

            // Para tags selecionadas no onboarding, soma 5 ao peso da tag
            foreach (var texto in tagsOnboarding)
            {
                if (tagsDic.ContainsKey(texto))
                    tagsDic[texto] += 5;
                else
                    tagsDic[texto] = 5;
            }

            tagsDic = tagsDic.OrderByDescending(x => x.Value).ToDictionary();
        }
        
        private void RanquearItens(
            IEnumerable<ItemCardapioDTO> itensCardapio,
            Dictionary<string, int> tagsDic,
            out IEnumerable<ItemCardapioRanqueado> itensRanqueados)
        {
            var itensTemp = new List<ItemCardapioRanqueado>();
            foreach (var item in itensCardapio)
            {
                var itemRanqueado = _mapper.Map<ItemCardapioRanqueado>(item);
                foreach (var tag in item.Tags)
                {
                    if (tagsDic.ContainsKey(tag))
                        itemRanqueado.Score += tagsDic[tag];
                }

                itensTemp.Add(itemRanqueado);
            }

            itensRanqueados = itensTemp.OrderByDescending(x => x.Score);
        }

        private static string MontarPromptGeracaoTag()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Você é um assistente que gera tags para identificar e classificar itens de um cardápio.");
            sb.AppendLine("Irei utilizar as tags geradas nos itens, para criar uma aba de itens recomendados para cada cliente, me baseando nas tags que mais aparecem nos pedidos anteriores dele.");
            sb.AppendLine("Considere para itens que são comidas, as seguintes categorias: hambúrguer, petisco, pizza, porção, fritura, salada, prato executivo, massa, grelhado, assado, doce, sobremesa.");
            sb.AppendLine("Considere para itens que são bebidas, as seguintes categorias: alcoólico, não Alcoólico, refrigerante, suco, drink, vinho, cerveja, destilado, chá.");
            sb.AppendLine("Para os itens que são comidas, considere as seguintes possíveis restrições alimentares: vegetariano, vegano, sem lactose, sem glúten, sem açúcar, low carb.");
            sb.AppendLine();
            sb.AppendLine("Irei te informar o nome e a descrição do item, categorize o item em 3 tags, existentes ou não nas tags listadas, como nos exemplos abaixo:");
            sb.AppendLine();
            sb.AppendLine("Nome: Caipirinha");
            sb.AppendLine("Descrição: O clássico drink brasileiro, refrescante como sempre");
            sb.AppendLine("Retorno esperado: alcoólico;drink;limão");
            sb.AppendLine("Outro retorno possível: alcoólico;drink;cachaça");
            sb.AppendLine();
            sb.AppendLine("Nome: Hambúrguer Vegetariano");
            sb.AppendLine("Descrição: Um delicioso hambúrguer feito com carne de soja e pão livre de glúten");
            sb.AppendLine("Retorno esperado: hambúrguer;vegetariano;sem glúten");
            sb.AppendLine();
            sb.AppendLine("Nome: Salada de Frutas");
            sb.AppendLine("Descrição: Salada que leva manga, maça, pera, abacaxi e suco de laranja.");
            sb.AppendLine("Retorno esperado: vegano;low carb; sem açúcar");
            sb.AppendLine("Outro possível retorno: vegano;sem glúten; sem lactose");
            sb.AppendLine("Não escreva nada na resposta a não ser as 3 tags, separadas por (;), como nos exemplos de retorno que forneci.");
            sb.AppendLine();
            sb.AppendLine("Dê mais relevância a restrição alimentar de vegetariano e vegano, sempre que identificar que um item alimentício (bebidas não é necessário), se encaixa como vegetariano ou vegano, de relevancia pra essa tag, obviamente gere somente 1 delas, se um item é vegano, ele é claramente vegetariano. Evite usar plurais, use as tags sempre no singular, a idéia aqui é padronizar as tags, para inferir o gosto pessoal do cliente pelos seus pedidos anteriores, tente ser mais generalista (por exemplo identificar em qual categoria do cardapio um item se encaixaria (petisco, hamburguer, pizza, drink, sobremesa, cerveja, etc)).");

            return sb.ToString();
        }

        private static void MontarPromptRecomendacaoGPT(
            IEnumerable<ItemCardapioRanqueado> itensRanqueados,
            Dictionary<string, int> tagsDic,
            IEnumerable<string> restricoesAlimentares,
            int maxItensRecomendados,
            out string promptRecomendacaoGPT)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Você receberá uma lista ordenada de itens do cardápio. Cada item contém:");
            sb.AppendLine("- Id: identificador único do item.");
            sb.AppendLine("- Nome: nome do prato ou bebida.");
            sb.AppendLine("- Descrição: descrição textual do item.");
            sb.AppendLine("- Tags: lista de palavras-chave relacionadas ao item.");
            sb.AppendLine("- Score: pontuação que indica alinhamento com as preferências do cliente.");
            sb.AppendLine();
            sb.AppendLine("Também receberá uma lista das tags mais relevantes para o cliente, com suas respectivas pontuações.");
            sb.AppendLine();
            sb.AppendLine("Além disso, há restrições alimentares do cliente que devem ser rigorosamente respeitadas.");
            sb.AppendLine();
            sb.AppendLine("Importante: embora algumas tags possam não estar explicitamente listadas nos itens, utilize seu conhecimento para identificar categorias ou características implícitas.");
            sb.AppendLine("Por exemplo, mesmo que um item como 'Moscow Mule' não tenha a tag 'drink', ele é um drink e deve ser considerado para fins de alinhamento com as preferências do cliente.");
            sb.AppendLine();
            sb.AppendLine("Sua tarefa é analisar cada item e recomendar até " + maxItensRecomendados + " itens que:");
            sb.AppendLine("1. Não violam nenhuma restrição alimentar (exclua itens que contenham ingredientes proibidos, mesmo que não explicitamente mencionados nas tags).");
            sb.AppendLine("2. Possuem maior alinhamento com as preferências indicadas pelas tags do cliente, considerando também categorias implícitas.");
            sb.AppendLine("3. Caso não existam itens que satisfaçam as condições acima, a lista de recomendações pode ser vazia.");
            sb.AppendLine();
            sb.AppendLine("Restrições alimentares do cliente:");
            if (restricoesAlimentares.Any())
                sb.AppendLine("- " + string.Join(", ", restricoesAlimentares));
            else
                sb.AppendLine("- Nenhuma");
            sb.AppendLine();
            sb.AppendLine("Tags mais relevantes do cliente e suas pontuações:");
            if (tagsDic.Any())
            {
                foreach (var tag in tagsDic)
                {
                    sb.AppendLine($"- {tag.Key}: {tag.Value}");
                }
            }
            else
            {
                sb.AppendLine("- Nenhuma tag relevante fornecida");
            }
            sb.AppendLine();
            sb.AppendLine("Itens do cardápio:");
            foreach (var item in itensRanqueados)
            {
                sb.AppendLine($"- Id: {item.Id}");
                sb.AppendLine($"  Nome: {item.Nome}");
                sb.AppendLine($"  Descrição: {item.Descricao}");
                sb.AppendLine($"  Tags: {(item.Tags != null && item.Tags.Any() ? string.Join(", ", item.Tags) : "Nenhuma")}");
                sb.AppendLine($"  Score: {item.Score}");
                sb.AppendLine();
            }
            sb.AppendLine("Liste os até " + maxItensRecomendados + " itens recomendados, ordenados do melhor para o menos indicado, considerando as restrições e preferências descritas.");
            sb.AppendLine("Não recomende itens que violem as restrições alimentares do cliente.");
            sb.AppendLine("Evite recomendar itens veganos ou vegetarianos para clientes que não possuem essas restrições.");
            sb.AppendLine("Tente variar nas recomendações, por exemplo não recomendar 5 sucos pro cliente, ou 5 hambúrgueres, tente recomendar itens variados (desde que estejam dentro do paladar do cliente).");
            sb.AppendLine("Lembre-se: o número de itens recomendados pode ser menor que " + maxItensRecomendados + " ou até mesmo vazio se não houver opções adequadas.");
            sb.AppendLine("Faça todo o raciocício para chegar até a sua resposta final, mas me retorne somente os ids dos itens escolhidos, em ordem do mais recomendado, separados por (;) dentro de um colchete.");
            sb.AppendLine("Exemplo de resposta final: [32;13;56;6]");
            sb.AppendLine("Exemplo de resposta final sem nenhuma recomendação: []");

            promptRecomendacaoGPT = sb.ToString();
        }

        #endregion
    }
}
