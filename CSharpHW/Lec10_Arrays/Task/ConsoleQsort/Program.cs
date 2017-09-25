using System;

namespace ConsoleHeapSort
{
    class Program
    {
        static void Main()
        {
            var arr = new[] { 1, 2, 4, 4, 5, 5, 6, 4, 4, 5, 6, 7, 2, 5, 4, 5, 23, 46, 213, 2, 1, -5, 0 };
            arr[300] = 6;
            PrintArray(HeapSort(arr));
        }

        static int[] HeapSort(int[] arr)
        {
            Heapify(arr);

            for (int end = arr.Length - 1; end > 0;)
            {
                Swap(ref arr[end], ref arr[0]);
                SiftDown(arr, 0, --end);
            }

            return arr;
        }

        static void Heapify(int[] arr)
        {
            for (int start = GetParentNum(arr.Length - 1); start >= 0; start--)
            {
                SiftDown(arr, start, arr.Length - 1);
            }
        }

        static void SiftDown(int[] arr, int start, int end)
        {
            for (int root = start; GetLeftChildNum(root) <= end;)
            {
                var child = GetLeftChildNum(root);
                var swap = root;

                if (arr[swap] < arr[child])
                {
                    swap = child;
                }
                if (child + 1 <= end && arr[swap] < arr[child + 1])
                {
                    swap = child + 1;
                }
                if (swap == root)
                {
                    return;
                }
                Swap(ref arr[root], ref arr[swap]);
                root = swap;
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static int GetParentNum(int n) => (n - 1) / 2;

        static int GetLeftChildNum(int n) => 2 * n + 1;

        static void PrintArray(int[] arr)
        {
            Console.Write($"{nameof(arr)} = [");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine($"{arr[arr.Length - 1]}\n]");
        }
    }
}