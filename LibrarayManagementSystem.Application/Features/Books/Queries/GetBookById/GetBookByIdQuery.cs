using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<ResultResponse<BookDto>>, IResponseData
    {
        public int Id { get; set; }
    }
}
