using System;
using ConsolePrintApp;

namespace ConsoleExtensions
{
    public static class PrinterExtensions
    {
        public static void Print(this string[] strArr)
        {
            var printer = new Printer();

            foreach (var str in strArr)
            {
                printer.Print(str);
            }
        }

        public static void Print(this string[] strArr, ConsoleColor color)
        {
            var printer = new ColourPrinter();

            foreach (var str in strArr)
            {
                printer.Print(str, color);
            }
        }

        public static void PrintPhoto(this string[] strArr)
        {
            var printer = new PhotoPrinter();
            var x = 2;
            var y = 10;
            
            for (int i = 0; i < strArr.Length; i++, y+=10)
            {
                printer.Print(strArr[i], x, y);
            }
        }

    }
}
