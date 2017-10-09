using System;
using System.IO;

namespace ParalelZip
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Enter path to folder to compress which:");
            var path = Console.ReadLine();
            DirectoryInfo directorySelected = new DirectoryInfo(path ?? throw new InvalidOperationException());
            if (directorySelected.Exists)
            {
                Console.WriteLine("---Start compression---");

                Zipper.Zip(directorySelected);

                Console.WriteLine("---Compression complete---");
            }
            else
            {
                Console.WriteLine("There is no such directory for compression");
            }


            Console.Write("Enter path to folder to decompress which:");
            path = Console.ReadLine();

            directorySelected = new DirectoryInfo(path ?? throw new InvalidOperationException());

            if (directorySelected.Exists)
            {
                Console.WriteLine("---Start decompression---");

                Zipper.Unzip(directorySelected);

                Console.WriteLine("---Decompression complete---");
            }
            else
            {
                Console.WriteLine("There is no such directory for decompression");
            }
        }
    }
}
