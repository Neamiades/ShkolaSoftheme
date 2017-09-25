using System;

namespace ConsoleLinkedListApp
{
    class Program
    {
        static void Main()
        {
            var x = new MyLinkedList<int> {1, 2, 3, 6, 10, 100, 50};
            ShowList(x);

            x.Add(13);

            ShowList(x);

            x.Remove(1);

            ShowList(x);

            Console.WriteLine($"Count = {x.Count}\n");

            foreach (var item in x.ToArray())
            {
                Console.Write($"{item}, ");
            }
        }

        static void ShowList<T>(MyLinkedList<T> list)
        {
            Console.Write("(");
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine(")\n");
        }
    }
}
