using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Contracts
{
    public interface IJwtService
    {
        string GenerateToken(User user, CancellationToken cancellationToken);
    }
}
