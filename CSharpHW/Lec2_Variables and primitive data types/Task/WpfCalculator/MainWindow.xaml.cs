using System;
using System.Windows;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();
        private const string Expr = "{0} {2} {1}";

        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Arg1.Text, out double arg1) &&
                double.TryParse(Arg2.Text, out double arg2))
            {
                double result;
                char operand;

                if (Addition.IsChecked != null && (bool)Addition.IsChecked)
                {
                    result = arg1 + arg2;
                    operand = '+';
                }
                else if (Subtraction.IsChecked != null && (bool)Subtraction.IsChecked)
                {
                    result = arg1 - arg2;
                    operand = '-';
                }
                else if (Multiplication.IsChecked != null && (bool)Multiplication.IsChecked)
                {
                    result = arg1 * arg2;
                    operand = '*';
                }
                else if (Division.IsChecked != null && (bool)Division.IsChecked)
                {
                    result = arg1 / arg2;
                    operand = '/';
                }
                else if (Remainder.IsChecked != null && (bool)Remainder.IsChecked)
                {
                    result = arg1 % arg2;
                    operand = '%';
                }
                else if (Pow.IsChecked != null && (bool)Pow.IsChecked)
                {
                    result = Math.Pow(arg1, arg2);
                    operand = '^';
                }
                else
                {
                    Result.Text = "You need to choose operand";
                    return;
                }

                Expression.Text = string.Format(Expr, Arg1.Text, Arg2.Text, operand);
                Result.Text = string.Format("{0:0.00}", result);
                return;
            }
            Result.Text = "Something wrong with arguments";
        }
        private void QuitClick(object sender, RoutedEventArgs e) => Close();
    }
}
