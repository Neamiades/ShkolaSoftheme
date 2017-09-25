using System;

namespace ConsoleCollections
{
    class Program
    {
        static void Main()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            var stack = new MyStack<int>();
            stack.Push(5);
            stack.Push(2);
            stack.Push(1);

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            var dictionary = new MyDictionary<int, double>();
            dictionary.Add(0, 2.0);
            dictionary.Add(1, 4.0);
            dictionary.Add(2, 6.0);
            dictionary.Add(3, 8.0);

            Console.WriteLine(dictionary.Remove(2));
            Console.WriteLine(dictionary.ContainsKey(2));
            Console.WriteLine((dictionary.TryGetValue(1, out double val), val));

        }
    }
}
