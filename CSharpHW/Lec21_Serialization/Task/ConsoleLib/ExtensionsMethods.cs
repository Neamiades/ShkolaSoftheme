using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.ComponentModel.DataAnnotations;

namespace ConsoleLib
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

        public static bool ValidateReader(this Reader reader)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(reader);
            if (!Validator.TryValidateObject(reader, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            Console.WriteLine("Auth '{0}' is complete", reader.Name);
            return true;
        }
    }
}
