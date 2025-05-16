using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IAtendimentoPedidoClienteRepository
    {
        Task<IEnumerable<AtendimentoPedidoCliente>> BuscarTodosPedidosPorClienteIdIncludingItens(int clienteId);
    }
}
