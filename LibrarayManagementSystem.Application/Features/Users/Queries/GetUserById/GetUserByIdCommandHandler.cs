using LibrarayManagementSystem.Application.Response;
using MediatR;

namespace LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, ResultResponse<UserDto>>
    {
        public Task<ResultResponse<UserDto>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
