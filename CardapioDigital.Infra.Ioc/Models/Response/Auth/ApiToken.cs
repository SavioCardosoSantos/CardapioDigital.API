namespace CardapioDigital.Infra.Ioc.Models.Response.Auth
{
    public class ApiToken
    {
        public string Token { get; set; }

        public ApiToken()
        {
            Token = string.Empty;
        }

        public ApiToken(string token)
        {
            Token = token;
        }
    }
}
