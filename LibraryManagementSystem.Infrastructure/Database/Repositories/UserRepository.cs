using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private UserManager<User> _userManager;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext applicationDbContext, ILogger<UserRepository> logger, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
            _userManager = userManager;
        }
        public async Task<bool> CreateAsync(User user, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }

        public async Task<IdentityResult> SetPasswordAsync(User user, string password, CancellationToken cancellationToken)
        {
            return await _userManager.AddPasswordAsync(user, password);
        }
        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<User?> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> ValidatePassword(User user, string password, CancellationToken cancellationToken)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
