using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Login
{
    public class LoginUserCommand : IRequest<ResultResponse<UserDto>>
    {
    }
}
