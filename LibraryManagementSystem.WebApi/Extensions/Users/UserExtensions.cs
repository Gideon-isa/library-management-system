using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Features.Users.Commands.Login;
using LibrarayManagementSystem.Application.Features.Users.Commands.Signup;
using LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using LibraryManagementSystem.WebApi.Services;
using System.Security.Claims;

namespace LibraryManagementSystem.Presentation.Extensions.Users
{
    public static class UserExtensions
    {
        public static CreateUserCommand ToCommand(this CreateUserRequest userRequest)
        {
            return new CreateUserCommand
            {
                FirstName = userRequest.FirstName.Trim(),
                LastName = userRequest.LastName.Trim(),
                UserName = userRequest.Username.Trim(),
                Email = userRequest.Email.Trim(),
                Password = userRequest.Password.Trim(),
                ReEnteredPassword = userRequest.ReEnteredPassword.Trim(),
                
            };
        }

        public static LoginUserCommand ToCommand(this LoginUserRequest loginUserRequest)
        {
            return new LoginUserCommand
            {
                UsernameOrEmail = loginUserRequest.UsernameOrEmail.Trim(),
                Password = loginUserRequest.Password.Trim(),
            };
        }

        public static GetUserByIdQuery ToCommand(Guid id)
        {
            return new GetUserByIdQuery
            {
                Id = id,
            };
        }

    }
}
