using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class RestricaoAlimentarService : IRestricaoAlimentarService
    {
        private readonly IRestricaoAlimentarRepository _repository;
        private readonly IMapper _mapper;

        public RestricaoAlimentarService(IRestricaoAlimentarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RestricaoAlimentarDTO> BuscarPorTexto(string texto)
        {
            string textoNormalizado = texto.ToLower().Trim();
            var restricao = await _repository.BuscarPorTexto(textoNormalizado);
            return _mapper.Map<RestricaoAlimentarDTO>(restricao);
        }

        public async Task<RestricaoAlimentarDTO> Inserir(string texto)
        {
            string textoNormalizado = texto.ToLower().Trim();
            var restricao = new RestricaoAlimentar(textoNormalizado);
            await _repository.Inserir(restricao);
            return await BuscarPorTexto(textoNormalizado);
        }
    }
}
