using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class TagItemCardapioService : ITagItemCardapioService
    {
        private readonly ITagItemCardapioRepository _repository;
        private readonly IRecommendationService _recommendationService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagItemCardapioService(ITagItemCardapioRepository repository, 
            IRecommendationService recommendationService,
            ITagService tagService,
            IMapper mapper)
        {
            _repository = repository;
            _recommendationService = recommendationService;
            _tagService = tagService;
            _mapper = mapper;
        }

        public async Task CadastrarTagsItem(ItemCardapioDTO itemCardapioId)
        {
            var tagsGeradas = await _recommendationService.GerarTags(itemCardapioId.Nome, itemCardapioId.Descricao);

            var tagsIds = new List<int>();
            foreach (var tag in tagsGeradas)
            {
                var tagExistente = await _tagService.BuscarPorTexto(tag);
                if (tagExistente == null)
                    tagExistente = await _tagService.Inserir(tag);

                tagsIds.Add(tagExistente.Id);
            }

            await Inserir(itemCardapioId.Id, tagsIds);
        }

        private async Task Inserir(int itemCardapioId, IEnumerable<int> tagsIds)
        {
            var listTagItemCardapio = new List<TagItemCardapio>();
            foreach (var tagId in tagsIds)
                listTagItemCardapio.Add(new TagItemCardapio(itemCardapioId, tagId));

            await _repository.InserirRange(listTagItemCardapio);
        }
    }
}
