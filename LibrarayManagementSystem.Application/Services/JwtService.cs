using LibrarayManagementSystem.Application.Contracts;
using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateToken(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
