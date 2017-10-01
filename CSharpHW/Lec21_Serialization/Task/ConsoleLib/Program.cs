using System;
using static System.Console;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleLib
{
    class Program
    {
        static void Main()
        {
            var lib = new Library();
            AddReaders(lib);
            try
            {
                ExtractBooks(lib);
                SaveBooks(lib);
            }
            catch (Exception)
            {
                WriteLine("Smth wrong with the books data files, please configurate app context");
                return;
            }

            Reader reader = AuthReader(lib);

            GiveABook(lib, reader);

            WriteLine("\nEnjoy reading and Good day!");
        }

        private static void ExtractBooks(Library lib)
        {
            var sw = Stopwatch.StartNew();
            lib.DownloadBooks(SerializeType.Binary);
            sw.Stop();
            WriteLine($"Binary deserialisation: {sw.Elapsed}");

            sw.Restart();
            lib.DownloadBooks(SerializeType.Xml);
            sw.Stop();
            WriteLine($"Xml deserialisation: {sw.Elapsed}");

            sw.Restart();
            lib.DownloadBooks(SerializeType.Protobuf);
            sw.Stop();
            WriteLine($"Protobuf deserialisation: {sw.Elapsed}");

            sw.Restart();
            lib.DownloadBooks(SerializeType.Json);
            sw.Stop();
            WriteLine($"Json deserialisation: {sw.Elapsed}");
        }

        private static void SaveBooks(Library lib)
        {
            var sw = Stopwatch.StartNew();
            lib.UploadBooks(SerializeType.Binary);
            sw.Stop();
            WriteLine($"Binary serialisation: {sw.Elapsed}");

            sw.Restart();
            lib.UploadBooks(SerializeType.Json);
            sw.Stop();
            WriteLine($"Json serialisation: {sw.Elapsed}");

            sw.Restart();
            lib.UploadBooks(SerializeType.Xml);
            sw.Stop();
            WriteLine($"Xml serialisation: {sw.Elapsed}");

            sw.Restart();
            lib.UploadBooks(SerializeType.Protobuf);
            sw.Stop();
            WriteLine($"Protobuf serialisation: {sw.Elapsed}");
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
    }
}