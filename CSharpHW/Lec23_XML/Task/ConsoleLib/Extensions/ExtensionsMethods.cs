using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConsoleLib.Models;

namespace ConsoleLib.Extensions
{
    static class ExtensionsMethods
    {
        public static void ValidateBook(this Book book)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!Validator.TryValidateObject(book, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                throw new ArgumentException();
            }
            Console.WriteLine("book '{0}' ({1}) is Valid", book.Name, book.Author);
        }
    }
}
