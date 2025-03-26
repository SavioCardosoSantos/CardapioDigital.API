using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestauranteItemCardapioRepository
    {
        Task Inserir(RestauranteItemCardapio item);
        Task Alterar(RestauranteItemCardapio item);
        Task<RestauranteItemCardapio?> BuscarPorId(int itemId);
        Task<IEnumerable<RestauranteItemCardapio>> ListarPorRestauranteId(int restauranteId);
        Task<IEnumerable<RestauranteItemCardapio>> ListarPorAbaId(int abaId);
    }
}
