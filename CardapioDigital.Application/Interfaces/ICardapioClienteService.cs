using CardapioDigital.Application.DTOs.CardapioCliente;

namespace CardapioDigital.Application.Interfaces
{
    public interface ICardapioClienteService
    {
        Task<CardapioResponse> BuscarCardapio(int restauranteId, int clienteId);
    }
}
