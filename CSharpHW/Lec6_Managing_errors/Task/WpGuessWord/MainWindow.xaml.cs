using System;
using System.Windows;

namespace WpGuessWord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        int _randomDigit;
        int _lives;
        Random _rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            SetRandomNum();
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            int guessedDigit;
            Message.Content = "";

            try
            {
                guessedDigit = int.Parse(Digit.Text);
            }
            catch (Exception exception)
            {
                Message.Content = exception.Message;
                return;
            }
            if (guessedDigit == _randomDigit)
            {
                Message.Content = "You guess a digit! Try again!";
                SetRandomNum();
            }
            else if (--_lives == 0)
            {
                Message.Content = "You don't guess a digit! Try again from start!";
                SetRandomNum();
            }
            else
            {
                Message.Content = "You don't guess a digit! Try again!";
                UpdateLivesCount();
            }
        }

        void SetRandomNum()
        {
            _randomDigit = _rnd.Next(1, 11);
            _lives = 3;
            UpdateLivesCount();
        }

        void UpdateLivesCount() => Lives.Content = _lives;
    }
}
