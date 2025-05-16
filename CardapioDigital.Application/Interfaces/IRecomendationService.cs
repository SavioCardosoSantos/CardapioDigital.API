using CardapioDigital.Application.DTOs;

namespace CardapioDigital.Application.Interfaces
{
    public interface IRecommendationService
    {
        Task<IEnumerable<string>> GerarTags(string nomeItem, string descricaoItem);
        Task<IEnumerable<ItemCardapioDTO>> MontarAbaRecomendados(
            IEnumerable<ItemCardapioDTO> itensCardapio,
            IEnumerable<string> tagsPedidosAnteriores,
            IEnumerable<string> tagsOnboarding,
            IEnumerable<string> restricoesAlimentares);
    }
}
