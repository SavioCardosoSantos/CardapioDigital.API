namespace CardapioDigital.Application.Interfaces
{
    public interface ITagClienteService
    {
        Task<IEnumerable<string>> BuscarTagsPorClienteId(int clienteId);
    }
}
