namespace LibrarayManagementSystem.Application.Options.Jwt
{
    public class JwtOptions
    {
        public const string Section = "JwtOptions";
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SigningKey { get; set; } = string.Empty;
        public string ExpirationInMinutes { get; set; } = string.Empty;
    }
}
