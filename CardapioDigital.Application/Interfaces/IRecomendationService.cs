namespace CardapioDigital.Application.Interfaces
{
    public interface IRecommendationService
    {
        Task<IEnumerable<string>> GerarTags(string nomeItem, string descricaoItem);
    }
}
