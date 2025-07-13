using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Signup
{
    public static class CreateCommandExtension
    {
        public static User ToEntity(this CreateUserCommand command)
        {
            return User.CreateUser(command.FirstName, command.LastName, command.Email, command.UserName);
        }

    }
}
