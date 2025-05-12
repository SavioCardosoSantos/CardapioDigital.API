using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TagDTO> BuscarPorTexto(string texto)
        {
            string textoNormalizado = texto.ToLower().Trim();
            var tag = await _repository.BuscarPorTexto(textoNormalizado);
            return _mapper.Map<TagDTO>(tag);
        }

        public async Task<TagDTO> Inserir(string texto)
        {
            string textoNormalizado = texto.ToLower().Trim();
            var tag = new Tag(textoNormalizado);
            await _repository.Inserir(tag);
            return await BuscarPorTexto(textoNormalizado);
        }
    }
}
