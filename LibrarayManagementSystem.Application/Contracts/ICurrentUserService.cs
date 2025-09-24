namespace LibrarayManagementSystem.Application.Contracts
{
    public interface ICurrentUserService
    {
        string? GetUserId();
        string? GetFullName();
    }
}
