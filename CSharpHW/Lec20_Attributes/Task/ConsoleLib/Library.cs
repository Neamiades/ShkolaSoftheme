using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace ConsoleLib
{
    class Library
    {
        public List<Book>   Books;
        public List<Reader> Readers;

        public Library()
        {
            Books = new List<Book>();
            Readers = new List<Reader>();
        }

        public bool HandOutBook(string name, string author, Reader reader)
        {
            try
            {
                if (ContainsBook(name, author))
                {
                    var book = Books.FirstOrDefault(b => b.Status == BookStatus.InStock && b.Name == name && b.Author == author);
                    if (book != null)
                    {
                        book.Status = BookStatus.OnHands;
                        book.Holder = reader;
                        book.ValidateBook();
                        WriteLine($"Book {book.Name} ({book.Author}) was given to reader {reader.Name}");
                        return true;
                    }
                    WriteLine("All books already on hands");
                    return false;
                }
                WriteLine("There is no such book");
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public void PrintStatistic()
        {
            WriteLine("--------------Library Statistic---------------\n");
            WriteLine($"In library are {Books.Count} book(s)");
            WriteLine($"--Available: {Books.Count(b => b.Status == BookStatus.InStock)}");
            WriteLine($"--On hands: {Books.Count(b => b.Status == BookStatus.OnHands)}\n");

            WriteLine($"--Fiction books: {Books.Count(b => b is FictionBook)}");
            WriteLine($"----Available: {Books.Count(b => b is FictionBook && b.Status == BookStatus.InStock)}");
            WriteLine($"----On hands: {Books.Count(b => b is FictionBook && b.Status == BookStatus.OnHands)}\n");

            WriteLine($"--Study books: {Books.Count(b => b is StudyBook)}");
            WriteLine($"----Available: {Books.Count(b => b is StudyBook && b.Status == BookStatus.InStock)}");
            WriteLine($"----On hands: {Books.Count(b => b is StudyBook && b.Status == BookStatus.OnHands)}\n");

            WriteLine($"--Science books: {Books.Count(b => b is ScienceBook)}\n");
        }

        public bool ContainsBook(string name, string author)
        {
            if (name != null && author != null)
            {
                return Books.Any(b => b.Name == name && b.Author == author);
            }
            if (name != null)
            {
                return Books.Any(b => b.Name == name);
            }
            if (author != null)
            {
                return Books.Any(b => b.Author == author);
            }

            return false;
        }

        public bool ContainsReader(Reader reader)
        {
            if (Readers.Any(r => r.Name == reader.Name && r.Signature == reader.Signature))
            {
                return true;
            }
            WriteLine("There is no such readers");
            return false;
        }

    }
}
