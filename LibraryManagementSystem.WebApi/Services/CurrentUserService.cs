using LibrarayManagementSystem.Application.Contracts;
using LibraryManagementSystem.WebApi.Extensions.Users;

namespace LibraryManagementSystem.WebApi.Services
{
    public class CurrentUserService(IHttpContextAccessor _contextAccessor) : ICurrentUserService
    {

        public string? GetFullName() => _contextAccessor.HttpContext?.User.GetFullName();

        public string? GetUserId() => _contextAccessor.HttpContext?.User.GetUserId();
    }
}
