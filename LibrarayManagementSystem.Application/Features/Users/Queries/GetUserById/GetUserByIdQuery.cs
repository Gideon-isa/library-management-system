using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultResponse<UserDto>>, IUserCommand
    {
        public Guid Id { get; set; }
    }
}
