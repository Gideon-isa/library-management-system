using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Contracts
{
    internal interface IJwtService
    {
        string GenerateToken(User user, CancellationToken cancellationToken);
    }
}
