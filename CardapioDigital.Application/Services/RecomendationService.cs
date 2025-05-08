using AutoMapper;
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
                var content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model = "gpt-4.1",
                        messages = new[] {
                        new { role = "system", content = "Sempre que o item for uma caipirinha, um hambúrguer vegetariano ou outros itens comuns, gere as mesmas 3 tags, que devem ser consistentes e enxutas. Exemplo: para caipirinha, as tags devem ser 'caipirinha', 'alcoólico', 'limão'. Para hambúrguer vegetariano, as tags devem ser 'hamburguer', 'vegetariano', 'plantbased'. Quando identificar outros itens, forneça as tags apropriadas. Não escreva nada na resposta a não ser as 3 tags, separadas por (;): ex (caipirinha;limão;alcoólico), palavras únicas que categorizam e identificam bem o item, para relação em um sistema de recomendação de itens de um cardápio digital, logo uma caipirinha e um moscow mule devem estar relacionados pela tag 'alcoólico'. Dê mais relevância a restrição alimentar de vegetariano e vegano, sempre que identificar que um item alimentício (bebidas não é necessário), se encaixa como vegetariano ou vegano, de relevancia pra essa tag, obviamente gere somente 1 delas, se um item é vegano, ele é claramente vegetariano. Evite usar plurais, use as tags sempre no singular, a idéia aqui é padronizar as tags, para inferir o gosto pessoal do cliente pelos seus pedidos anteriores, tente ser mais generalista (por exemplo identificar em qual categoria do cardapio um item se encaixaria (petisco, hamburguer, pizza, drink, sobremesa, cerveja, etc))." },
                        new { role = "user", content = $"Nome: {nomeItem}\nDescrição: {descricaoItem}" }
                        }
                    }),
                    Encoding.UTF8, "application/json"
                );

                var response = await _client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                var chatGptResponse = JsonConvert.DeserializeObject<ChatGptResponse>(responseBody);

                return chatGptResponse.Choices.First().Message.Content.Split(";").ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ocorreu uma falha ao gerar as tags para o item.\nErro: {ex.Message}");
            }
        }
    }
}
