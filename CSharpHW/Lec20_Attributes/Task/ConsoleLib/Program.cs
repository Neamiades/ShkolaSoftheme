using static System.Console;
using System.Collections.Generic;

namespace ConsoleLib
{
    class Program
    {
        static void Main()
        {
            var lib = new Library();
            AddBooks(lib);
            AddReaders(lib);
            WriteLine("Greatings, friend! This is a FunLib and a bit of information about us");
            lib.PrintStatistic();
            Reader reader = AuthReader(lib);

            GiveABook(lib, reader);

            WriteLine("\nEnjoy reading and Good day!");
        }

        private static Reader AuthReader(Library lib)
        {
            Reader reader;
            do
            {
                WriteLine("Authorize, enter your name and signature:");
                Write("Name: ");
                var readerName = ReadLine();

                Write("Signature: ");
                var signature = ReadLine();
                reader = new Reader { Name = readerName, Signature = signature };
            }
            while (!reader.ValidateReader() || !lib.ContainsReader(reader));
            return reader;
        }

        private static void GiveABook(Library lib, Reader reader)
        {
            string name, author;
            do
            {
                WriteLine("Choose book and we will send it to you, enter Name and Author");
                Write("Name: ");
                name = ReadLine();

                Write("Author: ");
                author = ReadLine();
            }
            while (!lib.HandOutBook(name, author, reader));
        }

        private static void AddReaders(Library lib)
        {
            lib.Readers.AddRange(new List<Reader>
            {
                new Reader {Name = "Alex Senior", Gender = ReaderGender.Male, Signature = "AS"},
                new Reader {Name = "Lana Fox", Gender = ReaderGender.Female, Signature = "LF"},
                new Reader {Name = "Nika Newton", Gender = ReaderGender.Female, Signature = "NN"},
                new Reader {Name = "Lisa Fayer", Gender = ReaderGender.Female, Signature = "SG"}
            });
        }

        private static void AddBooks(Library lib)
        {
            lib.Books.AddRange(new List<Book>
            {
                new FictionBook { Name = "Moon", Author = "Gerald", Genre = "Ballad" },
                new FictionBook { Name = "Sun", Author = "Forman", Genre = "Poem" },
                new StudyBook   { Name = "Basics", Author = "Gerald", Subject = "Physic" },
                new StudyBook   { Name = "Middle program", Author = "Frodo", Subject = "Physic"},
                new StudyBook   { Name = "Electricity", Author = "Ann", Subject = "Physic" },
                new ScienceBook { Name = "1+2", Author = "Fess", ResearchTheme = "Integrals" },
            });
        }
    }
}