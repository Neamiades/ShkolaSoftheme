using System;

namespace ConsolePrintApp
{
    public class ColourPrinter : Printer
    {
        public override void Print(string str)
        {
            Console.WriteLine($"It's print by {nameof(ColourPrinter)}:");
            base.Print(str);
        }

        public void Print(string str, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            base.Print(str);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
