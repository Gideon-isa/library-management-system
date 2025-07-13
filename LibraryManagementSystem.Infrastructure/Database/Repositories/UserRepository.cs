using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext applicationDbContext, ILogger<UserRepository> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }
        public async Task<User?> CreateAsync(User user, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Users.AddAsync(user, cancellationToken);
            _applicationDbContext.SaveChanges();
            return result.Entity;
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
