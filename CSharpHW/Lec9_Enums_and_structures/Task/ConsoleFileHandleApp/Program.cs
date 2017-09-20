using static System.Console;
using System.IO;

namespace ConsoleFileHandleApp
{
    class Program
    {
        static void Main()
        {
            Write("Enter the path to file: ");
            var pathToFile = ReadLine() ?? Directory.GetCurrentDirectory();

            Write("Enter the file access mode to file (Read, Write, ReadWrite): ");
            var accessModeToFile = ReadLine()?.ToLower();

            FileHandle? fileHandle = FileHandler.GetFileHandle(pathToFile, accessModeToFile);
            FileHandler.MakeActionsWithFile(fileHandle);

        }
    }
}

