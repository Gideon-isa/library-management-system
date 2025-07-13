using LibraryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Domain.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(User user, CancellationToken cancellationToken);
        Task<IdentityResult> SetPasswordAsync(User user, string password, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
        Task<bool> ValidatePassword(User user, string password,  CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken); 
        Task<User?> UpdateAsync(User user, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);

    }
}
