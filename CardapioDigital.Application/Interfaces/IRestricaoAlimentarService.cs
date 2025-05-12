using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRestricaoAlimentarService
    {
        Task<RestricaoAlimentarDTO> BuscarPorTexto(string texto);
        Task<RestricaoAlimentarDTO> Inserir(string texto);
    }
}
