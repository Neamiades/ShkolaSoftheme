using System;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace WpfRegisterForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        static readonly IFormatProvider Culture = new CultureInfo("uk-UA");

        public MainWindow() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            FNameText.BorderBrush = Brushes.GhostWhite;
            FNameErrLabel.Visibility = Visibility.Hidden;

            LNameText.BorderBrush = Brushes.GhostWhite;
            LNameErrLabel.Visibility = Visibility.Hidden;

            BDateText.BorderBrush = Brushes.GhostWhite;
            BDateErrLabel.Visibility = Visibility.Hidden;

            EmailText.BorderBrush = Brushes.GhostWhite;
            EmailErrLabel.Visibility = Visibility.Hidden;

            PhoneNumberText.BorderBrush = Brushes.GhostWhite;
            PhoneNumberErrLabel.Visibility = Visibility.Hidden;

            AddInfoText.BorderBrush = Brushes.GhostWhite;
            AddInfoErrLabel.Visibility = Visibility.Hidden;

            GenderErrLabel.Visibility = Visibility.Hidden;
            SuccesLabel.Visibility = Visibility.Hidden;

            if (FNameText.Text.Length > 255 || !Regex.IsMatch(FNameText.Text, @"^[a-zA-ZА-Яа-яёЁ]+$"))
            {
                FNameText.BorderBrush = Brushes.Red;
                FNameErrLabel.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (LNameText.Text.Length > 255 || !Regex.IsMatch(LNameText.Text, @"^[a-zA-ZА-Яа-яёЁ]+$"))
            {
                LNameText.BorderBrush = Brushes.Red;
                LNameErrLabel.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (!DateTime.TryParseExact(BDateText.Text, "dd/MM/yyyy", Culture, DateTimeStyles.AssumeLocal, out var d)
                || d.Year < 1900 || d.Year > DateTime.Today.Year)
            {
                BDateText.BorderBrush = Brushes.Red;
                BDateErrLabel.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (EmailText.Text.Length > 255 || !Regex.IsMatch(EmailText.Text, @"^[a-zA-Z]+@\w+\.com$"))
            {
                EmailText.BorderBrush = Brushes.Red;
                EmailErrLabel.Visibility = Visibility.Visible;
                isValid = false;
                
            }
            if (PhoneNumberText.Text.Length != 12 || !Regex.IsMatch(PhoneNumberText.Text, @"^[0-9]+$"))
            {
                PhoneNumberText.BorderBrush = Brushes.Red;
                PhoneNumberErrLabel.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (AddInfoText.Text.Length > 2000)
            {
                AddInfoText.BorderBrush = Brushes.Red;
                AddInfoErrLabel.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (!(bool)GMaleRadBut.IsChecked && !(bool)GFemaleRadBut.IsChecked)
            {
                GenderErrLabel.Visibility = Visibility.Visible;
            }
            if (isValid)
            {
                SuccesLabel.Visibility = Visibility.Visible;
            }

        }
    }
}
//First Name       - only letters, length < 255 symbols,
//Last Name        - only letters, length < 255 symbols,
//Birth date       - only numbers, 0 < day< 32, 0 < month< 13, 1900 < year<current year,
//Gender           - only male or female,
//Email            - should contains @, length< 255 symbols,
//Phone number     - only numbers, length = 12
//Additional info  - length< 2000 symbols.