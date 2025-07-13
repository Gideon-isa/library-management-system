using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Login
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultResponse<UserDto>>
    {
        public Task<ResultResponse<UserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
