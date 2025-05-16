using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.DTOs.CardapioCliente;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRestauranteAbaCardapioService
    {
        Task Inserir(AbaCardapioDTO aba);
        Task Alterar(AbaCardapioDTO aba);
        Task<IEnumerable<AbaCardapioDTO>> BuscarPorRestauranteId(int restauranteId);
        Task<IEnumerable<AbaCardapioClienteResponse>> BuscarPorRestauranteIdIncludeItens(int restauranteId);
        Task SalvarOrdenacao(int[] abaIds, int restauranteId);
        Task<AbaCardapioDTO> BuscarPorId(int abaId);
        Task Excluir(int abaId);
    }
}
