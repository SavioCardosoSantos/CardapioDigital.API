﻿namespace CardapioDigital.Util.Extensions
{
    public static class DateTimeExtension
    {
        public static bool MenorDeIdade(this DateTime? birthday)
        {
            return CalcAge(birthday ?? DateTime.MinValue, DateTime.Now) < 18;
        }
        public static bool MenorDeIdade(this DateTime birthday)
        {
            return ((DateTime?)birthday).MenorDeIdade();
        }

        public static int CalcAge(DateTime birthdate, DateTime today)
        {
            var age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
                age--;

            return age;
        }

        public static DateTime ZerarHoras(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
        }
    }
}
