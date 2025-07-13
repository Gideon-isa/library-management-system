namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public class LoginUserRequest
    {
        public required string UsernameOrEmail { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
