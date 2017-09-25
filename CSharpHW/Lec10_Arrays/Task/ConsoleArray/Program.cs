using System;

namespace ConsoleArray
{
    class Program
    {
        static void Main()
        {
            int[] arr = new int[10001];
            Console.WriteLine(GetUniqueDigit(FillArray(arr)));
        }

        static int GetUniqueDigit(int[] arr)
        {
            int digit = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                digit ^= arr[i];
            }

            return digit;
        }

        static int[] FillArray(int[] arr)
        {
            int i;

            for (i = 0; i < arr.Length / 2; i++)
            {
                arr[i] = i;
            }

            arr[i] = i;

            for (int n = 1 + i--; i > 0; i--, n++)
            {
                arr[n] = i;
            }

            return arr;
        }
    }
}


   