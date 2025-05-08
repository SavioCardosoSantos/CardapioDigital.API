using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRestauranteAbaCardapioService
    {
        Task Inserir(AbaCardapioDTO aba);
        Task Alterar(AbaCardapioDTO aba);
        Task<IEnumerable<AbaCardapioDTO>> BuscarPorRestauranteId(int restauranteId);
        Task SalvarOrdenacao(int[] abaIds, int restauranteId);
        Task<AbaCardapioDTO> BuscarPorId(int abaId);
        Task Excluir(int abaId);
    }
}
