using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserRepository userRepository, ILogger<GetUserByIdQueryHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<ResultResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id.ToString(), cancellationToken);

                if (user is not null)
                {
                    _logger.LogInformation("Details of user {@Id} retrieved", user.Id);
                    return ResultResponse<UserDto>.Success(user.ToDto(), HttpStatusCode.OK, "user retrieved successfully");
                }
                _logger.LogInformation("Details of user {@Id} was does not exits", user?.Id);
                return ResultResponse<UserDto>.Failure(new UserDto(), new Error("500", "user with Id does not exists"),
                    HttpStatusCode.OK, "user not retrieved");

            }
            catch (Exception)
            {
                _logger.LogError("user was not retrieved");
                return ResultResponse<UserDto>.Failure(new UserDto(), new Error("500", "unable to retrieve user"),
                    HttpStatusCode.InternalServerError, "something went wrong");
            }

        }
    }
}
