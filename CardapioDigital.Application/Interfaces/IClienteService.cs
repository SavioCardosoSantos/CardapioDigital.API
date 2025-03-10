using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IClienteService
    {
        Task Inserir(ClienteDTO clienteDTO);
        Task Alterar(ClienteDTO clienteDTO);
        Task Excluir(int clienteId);
        Task<ClienteDTO?> BuscarClientePorCpf(string cpf);
        Task<ClienteDTO?> BuscarClientePorId(int clienteId);
        Task<IEnumerable<ClienteDTO>> ListarTodos();
    }
}
