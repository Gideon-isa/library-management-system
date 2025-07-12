using LibraryManagementSystem.Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Domain.Entities
{
    public sealed class User : IdentityUser<Guid>, IAuditable
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }

        private User(string firstName, string lastName, string email, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            CreatedOn = DateTime.Now;
            Email = email;
            UserName = username;
        }


        public static User CreateUser(string firstName, string lastName, string email, string username)
        {
            return new User(firstName, lastName, email, username);
        }

        public void UpdateUser(string firstName, string lastName, string username, string modifiedBy)
        {
            FirstName = firstName;
            LastName = lastName;
            ModifiedOn = DateTime.UtcNow;
            ModifiedBy = modifiedBy;
        }
    }
}
