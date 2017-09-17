using static System.Console;

namespace ConsoleNumericDataTypes
{
    class Program
    {
        private const string Info = "Maximal value of {0} type: {1}\n" +
                                    "Minimal value of {0} type: {2}\n" +
                                    "Default value of {0} type: {3}";
        static void Main()
        {
            var menuText = "Enter the type you want to know about:\n" +
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
            while (PrintInfo()) { }
        }

        private static bool PrintInfo()
        {
            Write("Type : ");
            var type = ReadLine();
            switch (type.ToLower())
            {
                case "int":
                    WriteLine(string.Format(Info, "int",
                            int.MaxValue, int.MinValue, default(int)));
                    return true;
                case "long":
                    WriteLine(string.Format(Info, "long",
                            long.MaxValue, long.MinValue, default(long)));
                    return true;
                case "float":
                    WriteLine(string.Format(Info, "float",
                            float.MaxValue, float.MinValue, default(float)));
                    return true;
                case "double":
                    WriteLine(string.Format(Info, "double",
                            double.MaxValue, double.MinValue, default(double)));
                    return true;
                case "decimal":
                    WriteLine(string.Format(Info, "decimal",
                            decimal.MaxValue, decimal.MinValue, default(decimal)));
                    return true;
                case "string":
                    WriteLine(string.Format(Info, "string",
                            "\n\t1. Under the link https://msdn.microsoft.com/en-us/library/sx08afx2.aspx\n" +
                            "\t2. Or quick answer - 2 GB, or about 1 billion characters.", 0, "empty string \"\""));
                    return true;
                case "char":
                    WriteLine(string.Format(Info, "char",
                            (int)char.MaxValue, (int)char.MinValue, (int)default(char)));
                    return true;
                case "bool":
                    WriteLine(string.Format(Info, "bool",
                            true, false, default(bool)));
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
