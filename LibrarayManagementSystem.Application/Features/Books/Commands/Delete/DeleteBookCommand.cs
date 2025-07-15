using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Delete
{
    public class DeleteBookCommand : IRequest<ResultResponse<bool>>, IResponseData
    {
        public int Id { get; set; }
    }
}
