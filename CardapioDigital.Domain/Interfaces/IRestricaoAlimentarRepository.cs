using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestricaoAlimentarRepository
    {
        Task Inserir(RestricaoAlimentar restricao);
        Task Alterar(RestricaoAlimentar restricao);
        Task<RestricaoAlimentar?> BuscarPorTexto(string texto);
    }
}
