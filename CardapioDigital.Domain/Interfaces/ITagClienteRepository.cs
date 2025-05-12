using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface ITagClienteRepository
    {
        Task InserirRange(IEnumerable<TagCliente> listTagCliente);
        Task ExcluirRange(int clienteId);
    }
}
