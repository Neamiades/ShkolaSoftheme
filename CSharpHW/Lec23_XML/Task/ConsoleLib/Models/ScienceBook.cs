using ConsoleLib.Attributes;

namespace ConsoleLib.Models
{
    [OnlyForViewing]
    public class ScienceBook : Book
    {
        public string ResearchTheme { get; set; }

        public ScienceBook() { }

        public ScienceBook(Book book, string researchTheme)
        {
            Name = book.Name;
            Author = book.Author;
            Status = book.Status;
            ResearchTheme = researchTheme;
        }
    }
}
