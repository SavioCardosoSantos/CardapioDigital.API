using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface ITagService
    {
        Task<TagDTO> Inserir(string texto);
        Task<TagDTO> BuscarPorTexto(string texto);
    }
}
