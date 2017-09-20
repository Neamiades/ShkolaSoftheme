using static System.Console;
using System;
using System.Globalization;

namespace ConsoleZodiac
{
    enum ZodiacSigns
    {
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn,
        Aquarius,
        Pisces
    }

    class Program
    {
        static readonly IFormatProvider Culture = new CultureInfo("uk-UA");
        static void Main()
        {
            WriteLine("Enter birthdate in format DD/MM/YYYY:");

            while (BirthInfo()) { }
        }

        static bool BirthInfo()
        {
            Write("Birthdate: ");

            var input = ReadLine();

            if (input == null || input == "exit")
                return false;

            var birthDate = ValidDate(input.Split('/'));
            if (birthDate == null)
                WriteLine("Incorect date, try again");
            else
            {
                var now = DateTime.Today;
                int age = now.Year - birthDate.Value.Year;
                if (birthDate > now.AddYears(-age))
                    age--;
                int month = now.Month - birthDate.Value.Month;
                if (month < 0)
                    month = 12 + month;

                WriteLine($"Your age is: {age} years and {month} month(s)");
                WriteLine($"Your Zodiac sign is: {GetZodiac(birthDate.Value)}");
            }
            return true;
        }

        static DateTime? ValidDate(string[] date, int pos = 0)
        {
            switch (pos)
            {
                case 0:
                    if ((date.Length == 3 && date[pos].Length == 2)
                        && int.TryParse(date[pos], out int day)
                        && (day > 0 && day < 32))
                        {
                            return ValidDate(date, ++pos);
                        }
                    return null;
                case 1:
                    if (date[pos].Length == 2
                        && int.TryParse(date[pos], out int month)
                        && (month > 0 && month < 13))
                        {
                            return ValidDate(date, ++pos);
                        }
                    return null;
                case 2:
                    if (date[pos].Length == 4
                        && int.TryParse(date[pos], out int year)
                        && (year > 0 && year <= DateTime.Today.Year))
                    {
                        var resDate = DateTime.ParseExact(
                            string.Join("/", date),
                            "dd/MM/yyyy",
                            Culture, DateTimeStyles.AssumeLocal);
                        if (resDate <= DateTime.Today)
                        {
                            return resDate;
                        }
                    }
                    return null;
                default:
                    return null;
            }
        }
        static ZodiacSigns? GetZodiac(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                    if (date.Day < 20)
                        return ZodiacSigns.Capricorn;
                    return ZodiacSigns.Aquarius;
                case 2:
                    if (date.Day < 19)
                        return ZodiacSigns.Aquarius;
                    return ZodiacSigns.Pisces;
                case 3:
                    if (date.Day < 21)
                        return ZodiacSigns.Pisces;
                    return ZodiacSigns.Aries;
                case 4:
                    if (date.Day < 21)
                        return ZodiacSigns.Aries;
                    return ZodiacSigns.Taurus;
                case 5:
                    if (date.Day < 21)
                        return ZodiacSigns.Taurus;
                    return ZodiacSigns.Gemini;
                case 6:
                    if (date.Day < 21)
                        return ZodiacSigns.Gemini;
                    return ZodiacSigns.Cancer;
                case 7:
                    if (date.Day < 23)
                        return ZodiacSigns.Cancer;
                    return ZodiacSigns.Leo;
                case 8:
                    if (date.Day < 23)
                        return ZodiacSigns.Leo;
                    return ZodiacSigns.Virgo;
                case 9:
                    if (date.Day < 24)
                        return ZodiacSigns.Virgo;
                    return ZodiacSigns.Libra;
                case 10:
                    if (date.Day < 24)
                        return ZodiacSigns.Libra;
                    return ZodiacSigns.Scorpio;
                case 11:
                    if (date.Day < 22)
                        return ZodiacSigns.Scorpio;
                    return ZodiacSigns.Sagittarius;
                case 12:
                    if (date.Day < 22)
                        return ZodiacSigns.Sagittarius;
                    return ZodiacSigns.Capricorn;
            }
            return null;
        }
    }
}