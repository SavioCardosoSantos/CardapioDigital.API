using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestauranteItemCardapioRepository
    {
        Task Inserir(RestauranteItemCardapio item);
        Task Alterar(RestauranteItemCardapio item);
        Task AlterarRange(IEnumerable<RestauranteItemCardapio> itens);
        Task<RestauranteItemCardapio?> BuscarPorId(int itemId);
        Task<IEnumerable<RestauranteItemCardapio>> ListarPorRestauranteId(int restauranteId);
        Task<IEnumerable<RestauranteItemCardapio>> ListarPorAbaId(int abaId);
        Task<int> BuscarProximaOrdenacao(int restauranteId);
    }
}
