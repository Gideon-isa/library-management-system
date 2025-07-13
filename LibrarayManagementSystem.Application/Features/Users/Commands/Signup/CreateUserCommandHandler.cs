using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Signup
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserRepository userRepository,
            ILogger<CreateUserCommandHandler> logger, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _logger = logger;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                User user = request.ToEntity();

                await _unitOfWork.BeginTransactionAsync();
                var existingUser = await _userManager.FindByEmailAsync(request.Email);
                if (existingUser is not null) 
                {
                    return ResultResponse<UserDto>.Failure(new(), new Error("409", "email already exist"), HttpStatusCode.Conflict);
                }
                var isSucceeded = await _userRepository.CreateAsync(user, cancellationToken);
                if (isSucceeded is false)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return ResultResponse<UserDto>.Failure(new(), new Error("500", "Something went wrong"), HttpStatusCode.InternalServerError);
                }

                var result = await _userRepository.SetPasswordAsync(user, request.Password, cancellationToken);
                if (result.Succeeded is false)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return ResultResponse<UserDto>.Failure(new(), new Error("400", result.Errors.ToString()), HttpStatusCode.BadRequest);
                }

                await _unitOfWork.CommitTransactionAsync();
                //var saved = await _unitOfWork.SaveChangesAsync();
            
                var userDto = user.ToDto();
                return ResultResponse<UserDto>.Success(userDto, HttpStatusCode.Created, "user successfully created");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();

                return ResultResponse<UserDto>.Failure(new(), new Error("500", "Something went wrong"), HttpStatusCode.InternalServerError);
                
            }

        }
    }
}
