using AutoMapper;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class TagClienteService : ITagClienteService
    {
        private readonly ITagClienteRepository _repository;
        private readonly IMapper _mapper;

        public TagClienteService(ITagClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<string>> BuscarTagsPorClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
