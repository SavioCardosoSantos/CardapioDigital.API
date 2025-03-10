using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Alterar(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);

            var clienteExistente = _repository.BuscarClientePorCpf(clienteDTO.Cpf);
            if (clienteExistente != null)
            {
                if (clienteExistente.Id != clienteDTO.Id)
                    throw new Exception("O CPF informado já existe.");
            }

            await _repository.Alterar(cliente);
        }

        public async Task<ClienteDTO?> BuscarClientePorCpf(string cpf)
        {
            var cliente = await _repository.BuscarClientePorCpf(cpf);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO?> BuscarClientePorId(int clienteId)
        {
            var cliente = await _repository.BuscarClientePorId(clienteId);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task Excluir(int clienteId)
        {
            var cliente = await _repository.BuscarClientePorId(clienteId) ?? throw new Exception("Cliente não encontrado.");
            await _repository.Excluir(cliente);
        }

        public async Task Inserir(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);

            var clienteExistente = _repository.BuscarClientePorCpf(clienteDTO.Cpf);
            if (clienteExistente != null)
                throw new Exception("O CPF informado já existe.");

            await _repository.Inserir(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ListarTodos()
        {
            var cliente = await _repository.ListarTodos();
            return _mapper.Map<IEnumerable<ClienteDTO>>(cliente);
        }
    }
}
