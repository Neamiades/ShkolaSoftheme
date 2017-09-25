using static System.Console;
using System.Collections.Generic;

namespace ConsoleUserValidation
{
    class Program
    {
        private static Server _server;

        static void Main()
        {
            WriteLine(" -Name must starts with a letter (lowercase or uppercase)\n" +
                      "and then can have between 3 and 11 letters or numbers.\n" +
                      " -Email must comply with generally accepted rules\n" +
                      " -Password must be between 8 and 15 characters long, contain at least one number,\n" +
                      "contain at least one uppercase letter, contain at least one lowercase letter.\n" +
                      " -To exit: fill name, email and password with \"exit\"");

            _server = new Server(new List<User>(), new Validator());
            while (Input()){}
        }

        static bool Input()
        {
            WriteLine("\nSign in or Log in to the system...");
            Write("Input name: ");
            var name = ReadLine();

            Write("Input email: ");
            var email = ReadLine();

            Write("Input password: ");
            var password = ReadLine();

            if (name == "exit" && email == "exit" && password == "exit")
            {
                return false;
            }

            _server.LogIn(new User
            {
                Name = string.IsNullOrWhiteSpace(name) ? null : name,
                Email = string.IsNullOrWhiteSpace(email) ? null : email,
                Password = password
            });

            return true;
        }
    }
}
