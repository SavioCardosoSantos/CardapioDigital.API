using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestauranteAbaCardapioRepository
    {
        Task Inserir(RestauranteAbaCardapio aba);
        Task Alterar(RestauranteAbaCardapio aba);
        Task<RestauranteAbaCardapio?> BuscarPorId(int abaId);
        Task<IEnumerable<RestauranteAbaCardapio>> BuscarPorRestauranteId(int restauranteId);
        Task Excluir(RestauranteAbaCardapio aba);
    }
}
