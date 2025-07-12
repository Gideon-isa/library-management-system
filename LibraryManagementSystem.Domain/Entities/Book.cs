using LibraryManagementSystem.Domain.Primitives;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Book : IAuditable
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string ISBN { get; private set; } = string.Empty;
        public DateTime PublishedDate { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }

        private Book(int id, string title, string author, string isbn, DateTime publishedDate, string createdBy)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedDate = publishedDate;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }

        public static Book CreateBook(int id, string title, string author, string isbn, DateTime publishedDate, string createdBy)
        {
            return new Book(id, title, author, isbn, publishedDate, createdBy);
        }

        public void UpdateBook(string title, string author, string isbn, DateTime publishedDate, string modifiedBy)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedDate = publishedDate;
            ModifiedOn = DateTime.UtcNow;
            ModifiedBy = modifiedBy;
        }
    }
}
