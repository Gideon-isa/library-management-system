using LibrarayManagementSystem.Application.Features.Users.Commands.Signup;
using LibraryManagementSystem.WebApi.ApiModels.Common;

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
    }
}
