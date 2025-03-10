namespace CardapioDigital.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string email, string senha);
    }
}
