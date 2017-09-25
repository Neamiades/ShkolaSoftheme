using static System.Console;

namespace Lottery
{
    class Program
    {
        private static LotteryDigits _lottery;

        static void Main()
        {
            WriteLine("This is a GREAT LOTTERY!!!");
            WriteLine("Enter 6 digits between 1 and 9 to challange your luck or \"exit\" to end this:");
            _lottery = new LotteryDigits();

            while (Input()) { }
        }

        static bool Input()
        {
            Write("Your try: ");
            var inputStr = ReadLine()?.Split();
            if (inputStr == null || inputStr[0] == "exit")
            {
                return false;
            }
            if (_lottery.ValidateStrNumbers(inputStr))
            {
                if (_lottery.CheckNum(inputStr))
                {
                    WriteLine("You won!!! Congratz! Try again");
                    _lottery.GenerateNewDigits();
                }
                else
                {
                    WriteLine("You loose!!! Try again");
                }
            }
            else
            {
                WriteLine("You get incorrect input string! Try again");
            }
            
            return true;
        }
    }
}
