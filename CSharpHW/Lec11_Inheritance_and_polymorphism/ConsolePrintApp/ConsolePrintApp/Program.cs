using System;
using System.IO;

namespace ConsolePrintApp
{
    class Program
    {
        static void Main()
        {
            var printer = new Printer();

            printer.Print($"Hello from {nameof(printer)}");
            printer = new ColourPrinter();

            printer.Print($"Hello from {nameof(printer)} with ColourPrinter reference");

            var colourPrinter = new ColourPrinter();

            colourPrinter.Print($"Hello from {nameof(printer)}", ConsoleColor.Cyan);

            var photoPrinter = new PhotoPrinter();
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                @"..\..\images\bars.jpg");
            photoPrinter.Print("Hop-hey - Softheme say's");
            photoPrinter.Print(path, 5, 10);
        }
    }
}
