namespace CardapioDigital.Application.DTOs.Onboarding
{
    public class OnboardingRequest
    {
        public int ClienteId { get; set; }
        public List<string> TagsEscolhidas { get; set; } = new List<string>();
        public List<string> RestricoesEscolhidas { get; set; } = new List<string>();
    }
}
