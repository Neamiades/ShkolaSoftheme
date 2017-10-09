namespace ConsoleLib.Models
{
    public class FictionBook : Book
    {
        public string Genre { get; set; }

        public FictionBook() { }

        public FictionBook(Book book, string genre)
        {
            Name   = book.Name;
            Author = book.Author;
            Status = book.Status;
            Genre  = genre;
        }
    }
}
