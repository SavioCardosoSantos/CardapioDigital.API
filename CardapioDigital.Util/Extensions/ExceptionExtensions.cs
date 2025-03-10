namespace CardapioDigital.Util.Extensions
{
    public static class ExceptionExtensions
    {
        public static string RetonarMensagensException(this Exception exception)
        {
            if (exception.InnerException != null)
                return $"'{exception.Message}' => {exception.InnerException.RetonarMensagensException()}";

            return $"'{exception.Message}'";
        }
    }
}
