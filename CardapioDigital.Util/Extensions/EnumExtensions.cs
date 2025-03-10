using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace CardapioDigital.Util.Extensions
{
    public static class EnumExtension
    {
        public static bool EqualsAny<TEnum>(this TEnum e, params TEnum[] values) where TEnum : Enum
        {
            return Array.Exists(values, x => x.Equals(e));
        }
        public static bool EqualsAny<TEnum>(this TEnum e, params int[] values) where TEnum : Enum
        {
            return Array.Exists(values, x => x.Equals(Convert.ToInt32(e, CultureInfo.InvariantCulture)));
        }
        public static bool EqualsAny<TEnum>(this TEnum e, params int?[] values) where TEnum : Enum
        {
            return Array.Exists(values, x => x?.Equals(Convert.ToInt32(e, CultureInfo.InvariantCulture)) ?? false);
        }

        public static string? GetDescription(this Enum e)
        {
            if (e is null)
                return null;

            Type type = e.GetType();
            string? name = Enum.GetName(type, e);

            if (name != null)
            {
                FieldInfo? field = type.GetField(name!);

                if (field != null && Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    return attr.Description;
            }

            return null;
        }

        public static IEnumerable<string> GetDescriptions(this Enum e, bool allowNull = false)
        {
            var enumType = e.GetType();
            var values = Enum.GetValues(enumType).Cast<Enum>();

            foreach (var value in values.Where(e.HasFlag))
            {
                var description = value.GetDescription();

                if (allowNull || !string.IsNullOrEmpty(description))
                {
                    yield return description ?? string.Empty;
                }
            }
        }
    }
}
