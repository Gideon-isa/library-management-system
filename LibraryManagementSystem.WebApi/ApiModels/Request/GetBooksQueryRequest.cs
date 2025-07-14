namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public class GetBooksQueryRequest
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; } =  1;
        public int PageSize { get; set; } = 10;

    }
}
