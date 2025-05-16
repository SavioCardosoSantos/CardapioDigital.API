using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.DTOs.CardapioCliente;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Util.Extensions;

namespace CardapioDigital.Application.Services
{
    public class CardapioClienteService : ICardapioClienteService
    {
        private readonly IClienteService _clienteService;
        private readonly IRestauranteAbaCardapioService _abaCardapioService;
        private readonly IAtendimentoPedidoClienteService _pedidoClienteService;
        private readonly IRecommendationService _recommendationService;
        private readonly IMapper _mapper;

        public CardapioClienteService(IClienteService clienteService,
            IRestauranteAbaCardapioService abaCardapioService,
            IAtendimentoPedidoClienteService pedidoClienteService,
            IRecommendationService recommendationService,
            IMapper mapper)
        {
            _clienteService = clienteService;
            _abaCardapioService = abaCardapioService;
            _pedidoClienteService = pedidoClienteService;
            _recommendationService = recommendationService;
            _mapper = mapper;
        }

        public async Task<CardapioResponse> BuscarCardapio(int restauranteId, int clienteId)
        {
            var cliente = await _clienteService.BuscarClienteCompletoPorId(clienteId);

            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            var isClienteMenorIdade = cliente.DataNascimento.ToDateTime(TimeOnly.MinValue).MenorDeIdade();
            var abasCardapio = await _abaCardapioService.BuscarPorRestauranteIdIncludeItens(restauranteId);

            var itensCardapio = new List<ItemCardapioDTO>();
            foreach (var aba in abasCardapio)
            {
                if (isClienteMenorIdade)
                    itensCardapio.AddRange(aba.Itens.Where(item => !item.Tags.Contains("alcoólico")).ToList());
                else
                    itensCardapio.AddRange(aba.Itens);
            }

            var tagsPedidosAnteriores = new List<string>();
            var pedidos = await _pedidoClienteService.BuscarTodosPedidosPorClienteIdIncludingItens(clienteId);
            foreach (var pedido in pedidos)
                tagsPedidosAnteriores.AddRange(pedido.Item.Tags);

            var tagsOnboarding = cliente.TagClientes.Select(x => x.Tag.Texto).ToList();
            var restricoesAlimentares = cliente.RestricaoAlimentarClientes.Select(x => x.RestricaoAlimentar.Texto).ToList();

            var itensAbaRecomendados = await _recommendationService.MontarAbaRecomendados(itensCardapio, tagsPedidosAnteriores, tagsOnboarding, restricoesAlimentares);
            var abaRecomendacao = new AbaCardapioClienteResponse() 
            {
                Nome = "Recomendados para Você",
                Itens = itensAbaRecomendados,
            };

            var cardapioResponse = new CardapioResponse();
            cardapioResponse.Abas.Add(abaRecomendacao);

            foreach (var aba in abasCardapio)
            {
                if (isClienteMenorIdade)
                    aba.Itens = aba.Itens.Where(item => !item.Tags.Contains("alcoólico")).ToList();

                cardapioResponse.Abas.Add(aba);
            }

            return cardapioResponse;
        }
    }
}
