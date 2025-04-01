namespace CardapioDigital.API.Errors
{
    public class ApiException
    {
        public ApiException(string statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public string StatusCode { get; set; }
        public string Message { get; set; }
    }
}
