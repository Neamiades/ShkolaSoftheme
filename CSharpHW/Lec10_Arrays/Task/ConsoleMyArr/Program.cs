using System;

namespace ConsoleMyArr
{
    class Program
    {
        static void Main()
        {
            var arr  = new MyArray<int>    { 6, 5, 4, 5, 3, 5 };
            var arr2 = new MyArray<string> { "Softeam", "is", "great" };
            var arr3 = new MyArray<double> { 6, 5, 4, 5, 3, 5 };

            PrintArray(arr);
            PrintArray(arr2);

            //Demonstration of the Length property
            Console.Write("MyArray<double>:\n[ ");
            for (int i = 0; i < arr3.Lenght; i++)
            {
                Console.Write($"{arr[i]:0.00} ");
            }
            Console.WriteLine("]");
        }

        static void PrintArray<T>(MyArray<T> arr)
        {
            Console.Write($"MyArray<{typeof(T)}>:\n[ ");
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("]");
        }
    }
}