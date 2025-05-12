using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestricaoAlimentarClienteRepository
    {
        Task InserirRange(IEnumerable<RestricaoAlimentarCliente> listTagItensCardapio);
        Task ExcluirRange(int clienteId);
    }
}
