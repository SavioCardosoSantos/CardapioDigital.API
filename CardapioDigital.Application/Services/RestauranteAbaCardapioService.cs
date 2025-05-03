using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;

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
    }
}
