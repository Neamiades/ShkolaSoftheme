using System;

namespace ConsolePrintApp
{
    public class Printer
    {
        public virtual void Print(string str) => Console.WriteLine(str);
    }
}
