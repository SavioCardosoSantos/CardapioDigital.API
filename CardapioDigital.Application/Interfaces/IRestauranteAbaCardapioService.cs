using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRestauranteAbaCardapioService
    {
        Task Inserir(AbaCardapioDTO aba);
        Task Alterar(AbaCardapioDTO aba);
        Task<IEnumerable<AbaCardapioDTO>> BuscarPorRestauranteId(int restauranteId);
        Task Excluir(int abaId);
    }
}
