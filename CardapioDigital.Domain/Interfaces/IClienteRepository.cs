using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task Inserir(Cliente cliente);
        Task Alterar(Cliente cliente);
        Task Excluir(Cliente cliente);
        Task<Cliente?> BuscarClientePorCpf(string cpf);
        Task<Cliente?> BuscarClientePorId(int clienteId);
        Task<Cliente?> BuscarClientePorIdIncludeOnboarding(int clienteId);
        Task<IEnumerable<Cliente>> ListarTodos();
    }
}
