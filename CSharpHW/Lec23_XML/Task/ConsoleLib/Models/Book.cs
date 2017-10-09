using ConsoleLib.Enums;

namespace ConsoleLib.Models
{
    public class Book
    {
        public string     Name   { get; set; }

        public string     Author { get; set; }

        public BookStatus Status { get; set; }
    }
}
