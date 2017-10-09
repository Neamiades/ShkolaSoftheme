namespace ConsoleLib.Models
{
    public class StudyBook : Book
    {
        public string Subject { get; set; }

        public StudyBook() { }

        public StudyBook(Book book, string subject)
        {
            Name = book.Name;
            Author = book.Author;
            Status = book.Status;
            Subject = subject;
        }
    }
}
