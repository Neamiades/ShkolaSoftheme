using static System.Console;

namespace ConsoleLib.Application
{
    class Program
    {
        static void Main()
        {
            var lib = new Library();

            ProgramCycle(lib);
            lib.PrintStatistic();

            WriteLine("\nEnjoy reading and Good day!");
        }

        private static void ProgramCycle(Library lib)
        {
            WriteLine("You now in the E-Library, choose what you wan't to do:");
            WriteLine("Take a book: 1");
            WriteLine("Give a book: 2");
            WriteLine("Steel a book: 3");
            WriteLine("Close the program: exit");

            string choice;

            Write("Your choice: ");
            do
            {
                choice = ReadLine();
                switch (choice)
                {
                    case "1":
                        IssueABook(lib);
                        break;
                    case "2":
                        GiveABook(lib);
                        break;
                    case "3":
                        SteelABook(lib);
                        break;
                    case "exit":
                        return;
                    default:
                        WriteLine("Wrong input, try again");
                        break;
                }
                Write("Your next move: ");
            }
            while (true);
        }

        private static void IssueABook(Library lib)
        {
            string name, author;
            do
            {
                WriteLine("Choose book and we will send it to you, enter Name and Author or enter \"exit\" two times to get out");
                Write("Name: ");
                name = ReadLine();

                Write("Author: ");
                author = ReadLine();
            }
            while (name != "exit" && author != "exit" && !lib.HandOutBook(name, author));
        }

        private static void SteelABook(Library lib)
        {
            string name, author;

            WriteLine("You secretly crept into the library and yaw with a flashlight on the shelves.");
            WriteLine("You think what kind of book to take with you.");

            Write("You choose the author: ");
            author = ReadLine();

            Write("Then you choose name of this book: ");
            name = ReadLine();
            if (lib.LostABook(name, author))
            {
                WriteLine("Oh, you little thief, we still find you!");
            }
            else
            {
                WriteLine("So you got caught, thief!");
                WriteLine("You will not get the book, but you will like the cuff.");
            }
        }

        private static void GiveABook(Library lib)
        {
            WriteLine("You are imbued with good intentions and want to give your favorite childhood book.");

            Write("Your book author is: ");
            var author = ReadLine();

            Write("Your book name is: ");
            var name = ReadLine();

            Write("Your book type(Study, Fiction, Science) is: ");
            var type = ReadLine();

            switch (type.ToLowerInvariant())
            {
                case "study":
                    type = "StudyBook";
                    Write("Subject of your book is: ");
                    break;
                case "fiction":
                    type = "FictionBook";
                    Write("Genre of your book is: ");
                    break;
                case "science":
                    type = "ScienceBook";
                    Write("Research theme of your book is: ");
                    break;
                default:
                    Write("We are sorry, but we don't accept that kind of books :(");
                    return;
            }

            var customField = ReadLine();

            lib.AddABook(name, author, type, customField);

            WriteLine("Thank you, deer ^^");
        }
    }
}