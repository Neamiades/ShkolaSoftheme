using System;
using System.IO;

namespace StringReplacer
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter path to folder with files to replace string in:");
            var path = Console.ReadLine();
            DirectoryInfo directorySelected = new DirectoryInfo(path ?? throw new InvalidOperationException());
            if (directorySelected.Exists)
            {
                Console.Write("Enter string to replace:");
                var replStr = Console.ReadLine();

                Console.Write("Enter string to insert:");

                var newStr = Console.ReadLine();
                Console.WriteLine("---Start replacing---");

                Replacer.Replace(directorySelected, replStr, newStr);

                Console.WriteLine("---End replacing---");

                Console.WriteLine("---Write log to log file---");
                Replacer.WriteLogToFile();
            }
            else
            {
                Console.WriteLine("There is no such directory for files changing");
            }
        }
    }
}
