using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRestauranteService
    {
        Task Inserir(RestauranteDTO restauranteDTO);
        Task Alterar(RestauranteDTO restauranteDTO);
        Task AlterarSenha(RestauranteDTO restauranteDTO);
        Task Inativar(int restauranteId);
        Task Ativar(int restauranteId);
        Task<RestauranteDTO?> BuscarPorId(int restauranteId);
        Task<RestauranteDTO?> BuscarPorEmail(string email);
        Task<IEnumerable<RestauranteDTO>> ListarTodos();
    }
}
