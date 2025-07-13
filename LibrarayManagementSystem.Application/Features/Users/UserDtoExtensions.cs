using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Features.Users
{
    public static class UserDtoExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.UserName,
            };
        }
    }
}
