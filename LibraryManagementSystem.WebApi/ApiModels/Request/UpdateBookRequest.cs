namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public class UpdateBookRequest
    {
        public required string Title { get; set; } = string.Empty;
        public required string Author { get; set; } = string.Empty;
        public required string ISBN { get; set; } = string.Empty;
        public required string PublishedDate { get; set; }
    }
}
