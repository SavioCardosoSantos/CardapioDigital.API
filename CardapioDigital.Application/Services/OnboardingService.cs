using CardapioDigital.Application.DTOs.Onboarding;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class OnboardingService : IOnboardingService
    {
        private readonly ITagService _tagService;
        private readonly IRestricaoAlimentarService _restricaoAlimentarService;
        private readonly ITagClienteRepository _tagClienteRepository;
        private readonly IRestricaoAlimentarClienteRepository _restricaoAlimentarClienteRepository;

        public OnboardingService(ITagService tagService,
            IRestricaoAlimentarService restricaoAlimentarService,
            ITagClienteRepository tagClienteRepository,
            IRestricaoAlimentarClienteRepository restricaoAlimentarClienteRepository)
        {
            _tagService = tagService;
            _restricaoAlimentarService = restricaoAlimentarService;
            _tagClienteRepository = tagClienteRepository;
            _restricaoAlimentarClienteRepository = restricaoAlimentarClienteRepository;
        }

        public async Task CriarOnboardingCliente(OnboardingRequest request)
        {
            var tagsEscolhidas = new List<TagCliente>();
            foreach (var tag in request.TagsEscolhidas)
            {
                var tagDto = await _tagService.BuscarPorTexto(tag);
                if (tagDto == null)
                    tagDto = await _tagService.Inserir(tag);

                tagsEscolhidas.Add(new TagCliente(request.ClienteId, tagDto.Id));
            }

            var restricoesEscolhidas = new List<RestricaoAlimentarCliente>();
            foreach (var restricao in request.RestricoesEscolhidas)
            {
                var restricaoDto = await _restricaoAlimentarService.BuscarPorTexto(restricao);
                if (restricaoDto == null)
                    restricaoDto = await _restricaoAlimentarService.Inserir(restricao);

                restricoesEscolhidas.Add(new RestricaoAlimentarCliente(request.ClienteId, restricaoDto.Id));
            }

            await _restricaoAlimentarClienteRepository.InserirRange(restricoesEscolhidas);
            await _tagClienteRepository.InserirRange(tagsEscolhidas);
        }

        public async Task AtualizarOnboardingCliente(OnboardingRequest request)
        {
            await _tagClienteRepository.ExcluirRange(request.ClienteId);
            await _restricaoAlimentarClienteRepository.ExcluirRange(request.ClienteId);

            await CriarOnboardingCliente(request);
        }
    }
}
