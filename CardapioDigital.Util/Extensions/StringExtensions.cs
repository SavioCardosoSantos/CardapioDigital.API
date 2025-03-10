using System.Text;
using System.Text.RegularExpressions;

namespace CardapioDigital.Util.Extensions
{
    public static partial class StringExtension
    {
        public static bool AnyIsNullOrEmpty(this string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return Array.Exists(stringsToCheck, x => string.IsNullOrEmpty(x));
        }

        public static bool AllIsNullOrEmpty(this string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return stringsToCheck.Count(s => string.IsNullOrEmpty(s)).Equals(stringsToCheck.Length);
        }

        public static bool ContainsAll(this string str, params string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return stringsToCheck.Count(s => str.Contains(s, StringComparison.CurrentCulture)).Equals(stringsToCheck.Length);
        }

        public static bool ContainsAny(this string str, params string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return Array.Exists(stringsToCheck, s => str.Contains(s, StringComparison.CurrentCulture));
        }

        public static bool ContainsAny(this string str, bool ignoreCase, params string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return Array.Exists(stringsToCheck, s => str.Contains(s, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture));
        }

        public static bool ContainsAllIgnoreCase(this string str, params string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return stringsToCheck.Count(s => str.Contains(s, StringComparison.InvariantCultureIgnoreCase)).Equals(stringsToCheck.Length);
        }

        public static bool ContainsCountIgnoreCase(this string str, int countToCheck, params string[]? stringsToCheck)
        {
            if (stringsToCheck == null)
                return false;

            return stringsToCheck.Count(s => str.Contains(s, StringComparison.InvariantCultureIgnoreCase)).Equals(countToCheck);
        }



        public static string HashText(this string text, string salt)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Concat(text, salt)));
        }

        public static string? GetFirstName(this string? name)
        {
            if (string.IsNullOrEmpty(name))
                return name;
            return name.Trim().Split(" ")[0].FirstCharToUpper();
        }

        public static string FirstCharToUpper(this string? input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input.First().ToString().ToUpperInvariant(), input.ToLowerInvariant().AsSpan(1)),
            };
        }

        public static string ReplaceWithRegex(this string str, string pattern, string replacement)
        {
            return Regex.Replace(str, pattern, replacement, RegexOptions.CultureInvariant, matchTimeout: TimeSpan.FromMilliseconds(2000));
        }

        public static string RemoveWithRegex(this string str, string pattern)
        {
            return str.ReplaceWithRegex(pattern, "");
        }

        public static string RemoveWithRegex(this string str, Regex regex)
        {
            return regex.Replace(str, "");
        }

        public static int ParaInteiro(this string? valor, int defaultValue = 0)
        {
            return int.TryParse(valor, out int result) ? result : defaultValue;
        }

        public static List<int> ParaInteiros(this string? valor, char separador)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return [];
            List<int> numeros = new List<int>();

            var valores = valor.Split(new[] { separador }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in valores)
            {
                if (int.TryParse(item.Trim(), out var numero))
                {
                    numeros.Add(numero);
                }
            }

            return numeros;
        }

        public static bool ValidarCep(this string cep)
        {
            string cepLimpo = Regex.Replace(cep, @"[^0-9]", "", RegexOptions.CultureInvariant, matchTimeout: TimeSpan.FromMilliseconds(2000));
            if (cepLimpo.Length != 8)
            {
                return false;
            }

            if (Regex.IsMatch(cepLimpo, @"^(\d)\1+$", RegexOptions.CultureInvariant, matchTimeout: TimeSpan.FromMilliseconds(2000)))
            {
                return false;
            }

            return true;
        }

        public static byte[] ConvertBase64ToByteArray(this string base64)
        {
            try
            {
                var resultado = base64.RemoveMimeTypeBase64();
                if (string.IsNullOrEmpty(resultado))
                    return Array.Empty<byte>();

                return Convert.FromBase64String(resultado);
            }
            catch (Exception)
            {
                return Array.Empty<byte>();
            }
        }

        public static string RemoveMimeTypeBase64(this string base64)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(base64))
                    return string.Empty;

                var parts = base64.Split(new[] { ";base64," }, StringSplitOptions.None);
                return parts.Length > 1 ? parts[1] : base64;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string FormataCep(this string cep)
        {
            var cepDigit = new string(cep.Where(char.IsDigit).ToArray());
            if (cepDigit.Length == 8)
                return $"{cepDigit.Substring(0, 5)}-{cepDigit.Substring(5, 3)}";

            return cep;
        }

        public static string RemoverFormatacaoCep(this string cep)
        {
            return cep.Replace(".", "").Replace("-", "").Replace(" ", "");
        }
    }
}
