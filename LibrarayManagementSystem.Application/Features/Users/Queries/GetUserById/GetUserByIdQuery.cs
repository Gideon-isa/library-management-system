using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultResponse<UserDto>>, IResponseData
    {
        public Guid Id { get; set; }
    }
}
