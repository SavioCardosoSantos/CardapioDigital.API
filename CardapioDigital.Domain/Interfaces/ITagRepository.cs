using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task Inserir(Tag tag);
        Task Alterar(Tag tag);
        Task<Tag?> BuscarPorTexto(string texto);
    }
}
