using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IRestauranteRepository
    {
        Task Inserir(Restaurante cliente);
        Task Alterar(Restaurante cliente);
        Task<Restaurante?> BuscarPorId(int clienteId);
        Task<Restaurante?> BuscarPorEmail(string email);
        Task<IEnumerable<Restaurante>> ListarTodos();
        Task<Restaurante?> BuscarPorIdWithExcluidos(int restauranteId);
    }
}
