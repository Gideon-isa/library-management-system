using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest<ResultResponse<BookDto>>, IResponseData, IBookCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string PublishedDate { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
