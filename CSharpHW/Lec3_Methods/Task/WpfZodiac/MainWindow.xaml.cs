using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfZodiac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
        static readonly IFormatProvider Culture = new CultureInfo("uk-UA");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorOutput.Visibility = Visibility.Hidden;
            AgeLabel.Content = "";
            ZodiacLabel.Content = "";

            var birthDate = ValidDate(Date.Text.Split('/'));
            if (birthDate == null)
                ErrorOutput.Visibility = Visibility.Visible;
            else
            {
                var now = DateTime.Today;
                int age = now.Year - birthDate.Value.Year;
                if (birthDate > now.AddYears(-age))
                    age--;
                int month = now.Month - birthDate.Value.Month;
                if (month < 0)
                    month = 12 + month;

                AgeLabel.Content = $"{age} years and {month} month(s)";
                var zodiac = GetZodiac(birthDate.Value);

                //Image finalImage = new Image ();
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(@"pack://application:,,,/"
                                         + Assembly.GetExecutingAssembly().GetName().Name
                                         + ";component/"
                                         + $"img/{zodiac}.jpeg", UriKind.Absolute);
                logo.CacheOption = BitmapCacheOption.OnLoad;
                logo.EndInit();


                ZodiacImg.Source = logo;
                ZodiacLabel.Content = $"{zodiac}";
            }
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
                            return resDate;
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
