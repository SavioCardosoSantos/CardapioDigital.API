using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.DTOs.CardapioCliente;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Util.Extensions;

namespace CardapioDigital.Application.Services
{
    public class RestauranteAbaCardapioService : IRestauranteAbaCardapioService
    {
        private readonly IRestauranteAbaCardapioRepository _repository;
        private readonly IMapper _mapper;

        public RestauranteAbaCardapioService(IRestauranteAbaCardapioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Inserir(AbaCardapioDTO aba)
        {
            var restauranteAbaCardapio = _mapper.Map<RestauranteAbaCardapio>(aba);
            restauranteAbaCardapio.Ordenacao = await _repository.BuscarProximaOrdenacao(aba.RestauranteId);
            await _repository.Inserir(restauranteAbaCardapio);
        }

        public async Task Alterar(AbaCardapioDTO abaCardapioDTO)
        {
            var abaExistente = await _repository.BuscarPorId(abaCardapioDTO.Id);
            if (abaExistente == null)
                throw new Exception("Aba não encontrada.");

            abaExistente.Nome = abaCardapioDTO.Nome;
            await _repository.Alterar(abaExistente);
        }

        public async Task<IEnumerable<AbaCardapioDTO>> BuscarPorRestauranteId(int restauranteId)
        {
            var abasRestaurante = await _repository.BuscarPorRestauranteId(restauranteId);
            return _mapper.Map<IEnumerable<AbaCardapioDTO>>(abasRestaurante);
        }

        public async Task<IEnumerable<AbaCardapioClienteResponse>> BuscarPorRestauranteIdIncludeItens(int restauranteId)
        {
            var abasRestaurante = await _repository.BuscarPorRestauranteIdIncludeItens(restauranteId);
            var abasCardapio = new List<AbaCardapioClienteResponse>();

            foreach(var aba in abasRestaurante)
            {
                var itensDTO = new List<ItemCardapioDTO>();
                foreach (var item in aba.Itens)
                {
                    var itemDTO = _mapper.Map<ItemCardapioDTO>(item);
                    if (item.Imagem.Length > 0)
                        itemDTO.ImagemBase64 = item.Imagem.ConvertToBase64WithMimeType();

                    foreach (var tagItem in item.TagItemCardapios)
                        itemDTO.Tags.Add(tagItem.Tag.Texto);

                    itensDTO.Add(itemDTO);
                }

                abasCardapio.Add(new AbaCardapioClienteResponse(aba.Nome, itensDTO));
            }

            return abasCardapio;
        }

        public async Task Excluir(int abaId)
        {
            var abaRestaurante = await _repository.BuscarPorId(abaId) ?? throw new Exception("Aba não encontrada.");
            await _repository.Excluir(abaRestaurante);
        }

        public async Task<AbaCardapioDTO> BuscarPorId(int abaId)
        {
            var aba = await _repository.BuscarPorId(abaId);
            return _mapper.Map<AbaCardapioDTO>(aba);
        }

        public async Task SalvarOrdenacao(int[] abaIds, int restauranteId)
        {
            var abas = await _repository.BuscarPorRestauranteId(restauranteId);
            for (int i = 0; i < abaIds.Length; i++)
            {
                var aba = abas.First(x => x.Id == abaIds[i]);
                aba.Ordenacao = i + 1;
            }

            await _repository.AlterarRange(abas);
        }
    }
}
