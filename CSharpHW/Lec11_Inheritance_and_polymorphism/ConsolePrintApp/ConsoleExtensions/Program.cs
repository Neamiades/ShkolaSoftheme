using System;
using System.IO;

namespace ConsoleExtensions
{
    class Program
    {
        static void Main()
        {
            var strArr = new [] {"Hello", "I'm", "need", "some", "sleep"};
            var photoArr = new[] 
            {
                Path.Combine(Directory.GetCurrentDirectory(),
                    @"..\..\images\2927-1600x1200.jpg"),
                Path.Combine(Directory.GetCurrentDirectory(),
                @"..\..\images\3037-1920x1440.jpg")
            };

            strArr.Print();
            strArr.Print(ConsoleColor.Green);
            photoArr.PrintPhoto();
        }
    }
}
