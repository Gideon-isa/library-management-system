using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdCommand : IRequest<ResultResponse<UserDto>>
    {
    }
}
