using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

using ConsoleLib.Enums;
using ConsoleLib.Models;

namespace ConsoleLib.Application
{
    static class BooksKeeper
    {
        static private readonly XDocument _xdoc;
        static private readonly XElement  _root;
        static private readonly string    _docName;
        static private readonly string    _rootName;
        static private readonly string    _elemName;

        static BooksKeeper()
        {
            _docName  = "books.xml";
            _rootName = "ArrayOfBook";
            _elemName = "Book";
            _xdoc     = File.Exists(_docName) ? XDocument.Load(_docName) : CreateDoc();
            _xdoc     = XDocument.Load(_docName);
            _root     = _xdoc.Element(_rootName);
        }
        
        private static IEnumerable<XElement> FindElems(string name = "", string author = "", string status = "", string type = "", string param = "")
        {
            var bookElems = _xdoc.Element(_rootName).Elements(_elemName).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                bookElems = bookElems.Where(xe => xe.Element("Name").Value == name);
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                bookElems = bookElems.Where(xe => xe.Element("Author").Value == author);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                bookElems = bookElems.Where(xe => xe.Element("Status").Value == status);
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                bookElems = bookElems.Where(xe => xe.Attribute("type").Value == type);
                if (!string.IsNullOrWhiteSpace(param))
                {
                    switch (type)
                    {
                        case "FictionBook":
                            bookElems = bookElems.Where(xe => xe.Element("Genre").Value == param);
                            break;
                        case "ScienceBook":
                            bookElems = bookElems.Where(xe => xe.Element("ResearchTheme").Value == param);
                            break;
                        case "StudyBook":
                            bookElems = bookElems.Where(xe => xe.Element("Subject").Value == param);
                            break;
                    }
                }
            }

            return bookElems;
        }

        private static XDocument CreateDoc()
        {
            XDocument xdoc = new XDocument(new XElement(_rootName));
            xdoc.Save(_docName);

            return xdoc;
        }

        public static void PutBooks(params Book[] books)
        {
            foreach (var book in books)
            {
                var newElem = new XElement(_elemName,
                        new XAttribute("type", book.GetType().Name),
                        new XElement("Name", book.Name),
                        new XElement("Author", book.Author),
                        new XElement("Status", book.Status)
                        );
                var customElem =
                    book is FictionBook ? new XElement("Genre", ((FictionBook)book).Genre) :
                    book is ScienceBook ? new XElement("ResearchTheme", ((ScienceBook)book).ResearchTheme) :
                                          new XElement("Subject", ((StudyBook)book).Subject);
                newElem.Add(customElem);
                _root.Add(newElem);
            }

            _xdoc.Save(_docName);
        }

        public static void ChangeBook(Book neededBook, Book newBook)
        {
            var bookElem = FindElems(neededBook.Name, neededBook.Author, neededBook.Status.ToString()).SingleOrDefault();

            bookElem.Element("Name").Value = newBook.Name;
            bookElem.Element("Author").Value = newBook.Author;
            bookElem.Element("Status").Value = newBook.Status.ToString();

            _xdoc.Save(_docName);
        }

        public static Book GetBook(string name = "", string author = "", string status = "", string type = "", string param = "")
        {
            XElement bookElem = FindElems(name, author, status, type, param).FirstOrDefault();

            if (bookElem == null)
            {
                return null;
            }

            var book = new Book
            {
                Name   = bookElem.Element("Name")  .Value,
                Author = bookElem.Element("Author").Value,
                Status = (BookStatus)Enum.Parse(typeof(BookStatus), bookElem.Element("Status").Value)
            };

            return bookElem.Attribute("type").Value == "FictionBook" ? new FictionBook(book, bookElem.Element("Genre")        .Value) :
                   bookElem.Attribute("type").Value == "ScienceBook" ? new ScienceBook(book, bookElem.Element("ResearchTheme").Value) :
                   bookElem.Attribute("type").Value == "StudyBook"   ? new StudyBook(book, bookElem.Element("Subject")        .Value) :
                                                                           book;
        }

        public static bool DeleteBook(string name = "", string author = "", string status = "", string type = "", string param = "")
        {
            var bookElem = FindElems(name, author, status, type, param);

            if (bookElem == null)
            {
                return false;
            }
            bookElem.Remove();
            _xdoc.Save(_docName);
            return true;
        }

        public static IEnumerable<Book> SelectBooks(string name = "", string author = "", string status = "", string type = "", string param = "")
        {
            var booksElem = FindElems(name, author, status, type, param);

            if (booksElem == null)
            {
                return null;
            }
            var books = new List<Book>();

            foreach (var bookElem in booksElem)
            {
                var book = new Book
                {
                    Name   = bookElem.Element("Name")  .Value,
                    Author = bookElem.Element("Author").Value,
                    Status = (BookStatus)Enum.Parse(typeof(BookStatus), bookElem.Element("Status").Value)
                };

                switch (bookElem.Attribute("type").Value)
                {
                    case "FictionBook":
                        books.Add(new FictionBook(book, bookElem.Element("Genre").Value));
                        break;
                    case "ScienceBook":
                        books.Add(new ScienceBook(book, bookElem.Element("ResearchTheme").Value));
                        break;
                    case "StudyBook":
                        books.Add(new StudyBook(book, bookElem.Element("Subject").Value));
                        break;
                    default:
                        books.Add(book);
                        break;
                }
            }

            return books;
        }
    }
}
