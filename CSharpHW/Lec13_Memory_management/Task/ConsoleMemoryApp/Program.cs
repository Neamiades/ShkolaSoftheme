using System;

namespace ConsoleMemoryApp
{
    class Program
    {
        static void Main()
        {
            using (var resourseHolderBase = new ResourceHolderBase(@"F:\file.txt"))
            {
                resourseHolderBase.Write("Need more SLEEP!!!");
            }

            ResourceHolderDerived resourseHolderDerived;

            using (resourseHolderDerived = new ResourceHolderDerived(@"F:\file.txt"))
            {
                Console.WriteLine("Read with resourseHolderDerived:");
                Console.WriteLine(resourseHolderDerived.Read());
            }

            resourseHolderDerived.Dispose();
            var resourseHolderDerived2 = new ResourceHolderDerived(@"F:\file.txt");

            Console.ReadKey();
        }
    }
}
