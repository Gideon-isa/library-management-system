using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Login
{
    public class LoginUserCommand : IRequest<ResultResponse<UserDto>>, IUserCommand
    {
        public string UsernameOrEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
