namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public class CreateUserRequest
    {
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string ReEnteredPassword { get; set; } = string.Empty;
    }
}
