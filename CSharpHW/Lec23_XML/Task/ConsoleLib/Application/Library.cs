using System;
using System.Linq;
using System.Collections.Generic;

using ConsoleLib.Enums;
using ConsoleLib.Extensions;
using ConsoleLib.Models;

namespace ConsoleLib.Application
{
    class Library
    {
        public bool HandOutBook(string name, string author)
        {
            try
            {
                var book = BooksKeeper.GetBook(name, author, BookStatus.InStock.ToString());
                
                if (book != null)
                {
                    book.Status = BookStatus.OnHands;
                    book.ValidateBook();
                    book.Status = BookStatus.InStock;
                    var tokenBook = new Book { Author = book.Author, Name = book.Name, Status = BookStatus.OnHands };
                    BooksKeeper.ChangeBook(book, tokenBook);
                    Console.WriteLine($"Book {book.Name} ({book.Author}) was given to you");
                    return true;
                }

                Console.WriteLine("The is no such book or they already token");

                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public bool LostABook(string name, string author) => BooksKeeper.DeleteBook(name, author);

        public void AddABook(string name, string author, string type, string customField)
        {
            var book = new Book
            {
                Name = name,
                Author = author,
                Status = BookStatus.InStock
            };

            switch (type)
            {
                case "FictionBook":
                    BooksKeeper.PutBooks(new FictionBook(book, customField));
                    break;
                case "StudyBook":
                    BooksKeeper.PutBooks(new StudyBook(book, customField));
                    break;
                case "ScienceBook":
                    BooksKeeper.PutBooks(new ScienceBook(book, customField));
                    break;
            }
        }

        public void PrintStatistic()
        {
            var books = BooksKeeper.SelectBooks();

            Console.WriteLine("--------------Library Statistic---------------\n");
            Console.WriteLine($"In library are {books.Count()} book(s)");
            Console.WriteLine($"--Available: {books.Count(b => b.Status == BookStatus.InStock)}");
            Console.WriteLine($"--On hands: {books.Count(b => b.Status == BookStatus.OnHands)}\n");

            Console.WriteLine($"--Fiction books: {books.Count(b => b is FictionBook)}");
            Console.WriteLine($"----Available: {books.Count(b => b is FictionBook && b.Status == BookStatus.InStock)}");
            Console.WriteLine($"----On hands: {books.Count(b => b is FictionBook && b.Status == BookStatus.OnHands)}\n");

            Console.WriteLine($"--Study books: {books.Count(b => b is StudyBook)}");
            Console.WriteLine($"----Available: {books.Count(b => b is StudyBook && b.Status == BookStatus.InStock)}");
            Console.WriteLine($"----On hands: {books.Count(b => b is StudyBook && b.Status == BookStatus.OnHands)}\n");

            Console.WriteLine($"--Science books: {books.Count(b => b is ScienceBook)}\n");
        }

        public bool ContainsBook(string name, string author) => BooksKeeper.GetBook(name, author) != null;
    }
}
