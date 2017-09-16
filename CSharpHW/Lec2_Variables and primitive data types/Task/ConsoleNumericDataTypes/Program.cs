using static System.Console;

namespace ConsoleNumericDataTypes
{
    class Program
    {
        static void Main()
        {
            var menuText = "Enter the type you want to know about:" +
                           "- int\n" +
                           "- long\n" +
                           "- float\n" +
                           "- double\n" +
                           "- decimal\n" +
                           "- string\n" +
                           "- char\n" +
                           "- bool\n" +
                           "Type \"exit\" to end the program\n";
            WriteLine(menuText);
            while (PrintInfo())
            {
                
            }

        }

        private static bool PrintInfo()
        {
            Write("Type : ");
            var type = ReadLine();
            switch (type.ToLower())
            {
                case "int":
                    WriteLine($"Maximal value of int type: {int.MaxValue}");
                    WriteLine($"Minimal value of int type: {int.MinValue}");
                    WriteLine($"Default value of int type: {default(int)}");
                    return true;
                case "long":
                    WriteLine($"Maximal value of long type: {long.MaxValue}");
                    WriteLine($"Minimal value of long type: {long.MinValue}");
                    WriteLine($"Default value of long type: {default(long)}");
                    return true;
                case "float":
                    WriteLine($"Maximal value of float type: {float.MaxValue}");
                    WriteLine($"Minimal value of float type: {float.MinValue}");
                    WriteLine($"Default value of float type: {default(float)}");
                    return true;
                case "double":
                    WriteLine($"Maximal value of double type: {double.MaxValue}");
                    WriteLine($"Minimal value of double type: {double.MinValue}");
                    WriteLine($"Default value of double type: {default(double)}");
                    return true;
                case "decimal":
                    WriteLine($"Maximal value of decimal type: {decimal.MaxValue}");
                    WriteLine($"Minimal value of decimal type: {decimal.MinValue}");
                    WriteLine($"Default value of decimal type: {default(decimal)}");
                    return true;
                case "string":
                    WriteLine("Maximal value of string type:\n" +
                                "\t1. Under the link https://msdn.microsoft.com/en-us/library/sx08afx2.aspx\n" +
                                "\t2. Or quick answer - 2 GB, or about 1 billion characters.");
                    WriteLine("Minimal value of string type: 0");
                    WriteLine("Default value of string type: empty string \"\"");
                    return true;
                case "char":
                    WriteLine($"Maximal value of char type: {(int)char.MaxValue}");
                    WriteLine($"Minimal value of char type: {(int)char.MinValue}");
                    WriteLine($"Default value of char type: {(int)default(char)}");
                    return true;
                case "bool":
                    WriteLine($"Maximal value of bool type: {true}");
                    WriteLine($"Minimal value of bool type: {false}");
                    WriteLine($"Default value of bool type: {default(bool)}");
                    return true;
                case "exit":
                    return false;
                default:
                    WriteLine("There is no such type in the program options");
                    return true;
            }
        }
    }
}
