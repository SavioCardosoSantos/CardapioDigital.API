using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestauranteAbaCardapioRepository
    {
        Task Inserir(RestauranteAbaCardapio aba);
        Task Alterar(RestauranteAbaCardapio aba);
        Task AlterarRange(IEnumerable<RestauranteAbaCardapio> abas);
        Task<RestauranteAbaCardapio?> BuscarPorId(int abaId);
        Task<int> BuscarProximaOrdenacao(int restauranteId);
        Task<IEnumerable<RestauranteAbaCardapio>> BuscarPorRestauranteId(int restauranteId);
        Task<IEnumerable<RestauranteAbaCardapio>> BuscarPorRestauranteIdIncludeItens(int restauranteId);
        Task Excluir(RestauranteAbaCardapio aba);
    }
}
