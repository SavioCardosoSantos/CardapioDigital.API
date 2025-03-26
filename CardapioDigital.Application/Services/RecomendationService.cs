using AutoMapper;
using CardapioDigital.Application.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class RecomendationService : IRecomendationService
    {
        private readonly IMapper _mapper;

        public RecomendationService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
