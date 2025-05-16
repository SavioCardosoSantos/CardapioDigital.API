using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IAtendimentoPedidoClienteService
    {
        Task<IEnumerable<PedidoClienteDTO>> BuscarTodosPedidosPorClienteIdIncludingItens(int clienteId);
    }
}
