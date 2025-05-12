using CardapioDigital.Application.DTOs.Onboarding;

namespace CardapioDigital.Application.Interfaces
{
    public interface IOnboardingService
    {
        Task CriarOnboardingCliente(OnboardingRequest request);
        Task AtualizarOnboardingCliente(OnboardingRequest request);
    }
}
