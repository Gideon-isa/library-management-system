using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Signup
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultResponse<UserDto>>
    {

        public Task<ResultResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
