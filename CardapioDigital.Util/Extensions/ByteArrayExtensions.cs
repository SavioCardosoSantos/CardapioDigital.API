namespace CardapioDigital.Util.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ConvertToBase64WithMimeType(this byte[] data)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentException("O array de bytes está vazio ou é nulo.");

            string mimeType = GetMimeTypeFromBytes(data) ?? "application/octet-stream";
            string base64Data = Convert.ToBase64String(data);

            return $"data:{mimeType};base64,{base64Data}";
        }



        #region Métodos privados da classe
        // Dicionário de assinaturas de arquivos e seus MIME Types
        private static readonly Dictionary<string, string> fileSignatures = new Dictionary<string, string>
        {
            { "FFD8FF", "image/jpeg" },
            { "89504E47", "image/png" },
            { "47494638", "image/gif" },
            { "25504446", "application/pdf" },
            { "504B0304", "application/zip" },
        };

        private static string? GetMimeTypeFromBytes(byte[] data)
        {
            string hex = BitConverter.ToString(data.Take(4).ToArray()).Replace("-", "");
            var matchingSignature = fileSignatures.FirstOrDefault(sig => hex.StartsWith(sig.Key));
            return matchingSignature.Value;
        }
        #endregion
    }
}
