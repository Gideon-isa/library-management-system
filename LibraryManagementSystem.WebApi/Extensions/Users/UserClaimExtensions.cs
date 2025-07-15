using System.Security.Claims;

namespace LibraryManagementSystem.WebApi.Extensions.Users
{
    public static class UserClaimExtensions
    {
        public static string? GetFirstName(this ClaimsPrincipal principal) => principal?.FindFirstValue(ClaimTypes.Name);
        public static string? GetLastName(this ClaimsPrincipal principal) => principal?.FindFirstValue(ClaimTypes.Surname);

        public static string? GetFullName(this ClaimsPrincipal principal)
        {
            var first = principal?.GetFirstName();
            var last = principal?.GetLastName();
            return $"{first} {last}".Trim();
        }
    }
}
