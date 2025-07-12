using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User?> CreateAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken); 
        Task<User?> UpdateAsync(User user, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);

    }
}
