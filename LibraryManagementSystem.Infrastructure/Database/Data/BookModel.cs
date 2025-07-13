using CsvHelper.Configuration.Attributes;

namespace LibraryManagementSystem.Infrastructure.Database.Data
{
    internal class BookModel
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        [Format("yyyy-MM-dd")]
        public DateTime PublishedDate { get; set; }
    }
}
