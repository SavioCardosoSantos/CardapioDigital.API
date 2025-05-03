using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface ITagItemCardapioService
    {
        Task CadastrarTagsItem(ItemCardapioDTO itemCardapioId);
    }
}
