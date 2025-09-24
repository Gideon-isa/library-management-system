using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<ResultResponse<BookDto>>,IResponseData, IBookCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string PublishedDate { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
    }
}
