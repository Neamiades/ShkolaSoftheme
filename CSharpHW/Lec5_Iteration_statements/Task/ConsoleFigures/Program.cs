using static System.Console;

namespace ConsoleFigures
{
    class Program
    {
        static void Main()
        {
            WriteLine("Choose figure which you want to print (Triangle, Square, Romb) " +
                      "and its size like: Romb 4\n" +
                      "Or print \"Exit\" to end program");
            while (PrintFigure()) { }
        }

        static bool PrintFigure()
        {
            Write("Your choise is: ");
            var input = ReadLine().Split();
            if (input[0] == "exit")
            {
                WriteLine("Good luck to you!");
                return false;
            }
            if (input.Length != 2 || !int.TryParse(input[1], out int size))
            {
                WriteLine("You print smth wrong :(");
                return true;
            }
            switch (input[0].ToLower())
            {
                case "triangle":
                    PrintTriangle(size);
                    return true;
                case "square":
                    PrintSquare(size);
                    return true;
                case "romb":
                    PrintRomb(size);
                    return true;
                default:
                    WriteLine("I don't understand what figure you want");
                    return true;
            }
        }

        static void PrintTriangle(int size = 5)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Write("*");
                }
                WriteLine();
            }
        }

        static void PrintSquare(int size = 5)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Write("*");
                }
                WriteLine();
            }
        }

        static void PrintRomb(int size = 5)
        {
            for (var i = 1; i <= size; i++)
            {
                for (var j = 0; j < size - i; j++)
                {
                    Write(" ");
                }
                for (var j = 0; j < (2 * i - 1); j++)
                {
                    Write("*");
                }

                WriteLine();
            }

            for (var i = size - 1; i > 0; i--)
            {
                for (var j = 0; j < size - i; j++)
                {
                    Write(" ");
                }
                for (var j = 0; j < (2 * i - 1); j++)
                {
                    Write("*");
                }

                WriteLine();
            }
        }
    }
}
