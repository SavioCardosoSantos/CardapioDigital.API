using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRestauranteItemCardapioService
    {
        Task Inserir(ItemCardapioDTO item);
        Task Alterar(ItemCardapioDTO item);
        Task<IEnumerable<ItemCardapioDTO>> BuscarPorAbaCardapioId(int abaCardapioId, int restauranteId);
        Task SalvarOrdenacao(int[] itemIds, int abaCardapioId, int restauranteId);
        Task Inativar(int itemCardapioId, int restauranteId);
        Task Ativar(int itemCardapioId, int restauranteId);
        Task Excluir(int itemCardapioId, int restauranteId);
    }
}
