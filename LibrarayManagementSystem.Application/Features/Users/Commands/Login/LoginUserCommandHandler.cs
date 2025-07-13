using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(IUserRepository userRepository, IJwtService jwtService, ILogger<LoginUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _logger = logger;
        }
        public async Task<ResultResponse<UserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User? user;

                if (request.UsernameOrEmail.Contains('@'))
                {
                   user = await _userRepository.GetByEmailAsync(request.UsernameOrEmail, cancellationToken); 
                }
                else
                { 
                    user = await _userRepository.GetByUsername(request.UsernameOrEmail, cancellationToken);
                }

                if (user is not null)
                {
                    var isValidPassword = await _userRepository.ValidatePassword(user, request.Password, cancellationToken);
                    if (isValidPassword)
                    {
                        
                        var jwtToken = _jwtService.GenerateToken(user, cancellationToken);
                        return ResultResponse<UserDto>.Success(user.ToDto(jwtToken), HttpStatusCode.OK, "login successfully");
                    }
                    return ResultResponse<UserDto>.Failure(null, new Error("400", "Invalid credentails"), HttpStatusCode.BadRequest, "Invalid credentails");
                }
                return ResultResponse<UserDto>.Failure(null, new Error("400", "User Not Found"), HttpStatusCode.NotFound, "User with credentsils not in our system");
            }
            catch (Exception)
            {
                return ResultResponse<UserDto>.Failure(null, new Error("500", "Internal server error"), HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
