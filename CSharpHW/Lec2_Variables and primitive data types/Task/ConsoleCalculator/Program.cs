using System;

namespace ConsoleCalculator
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Hello! This is the console calculator application!");
                Console.WriteLine("Enter your expression in format [Num arg1] [Math operand] [Num arg2]:");
                args = Console.ReadLine().Split();
            }
            if (args.Length == 3
                && double.TryParse(args[0], out var arg1)
                && double.TryParse(args[2], out var arg2))
            {
                switch (args[1])
                {
                    case "+":
                        Console.WriteLine($"Result: {arg1 + arg2:0.00}");
                        break;
                    case "-":
                        Console.WriteLine($"Result: {arg1 - arg2:0.00}");
                        break;
                    case "*":
                        Console.WriteLine($"Result: {arg1 * arg2:0.00}");
                        break;
                    case "/":
                        Console.WriteLine($"Result: {arg1 / arg2:0.00}");
                        break;
                    case "%":
                        Console.WriteLine($"Result: {arg1 % arg2:0.00}");
                        break;
                    case "^":
                        Console.WriteLine($"Result: {Math.Pow(arg1, arg2):0.00}");
                        break;
                    default:
                        ErrorOutput();
                        break;
                }
                return;
            }
            ErrorOutput();
        }

        private static void ErrorOutput()
        {
            Console.WriteLine("Invalid input");
            Console.WriteLine(@"Example of use: .\ConsoleCalculator.exe [Num arg1] [Math operand] [Num arg2]");
            Console.WriteLine(@"Example: .\ConsoleCalculator.exe 5.9 / 1.3");
        }
    }
}
