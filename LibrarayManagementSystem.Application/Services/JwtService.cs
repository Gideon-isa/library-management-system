using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Options.Jwt;
using LibraryManagementSystem.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace LibrarayManagementSystem.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptionsMonitor<JwtOptions> _jwtOptions;
        private readonly ILogger<JwtService> _logger;

        public JwtService(IOptionsMonitor<JwtOptions> jwtOptions, ILogger<JwtService> logger)
        {
            _jwtOptions = jwtOptions;
            _logger = logger;
        }
        public string GenerateToken(User user, CancellationToken cancellationToken)
        {
            try
            {
                var now = DateTime.UtcNow;
                JwtSecurityTokenHandler jwtHandler = new();

                var secretKey = _jwtOptions.CurrentValue.SigningKey;
                var encodedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.Name, user.FirstName ?? "Unknown"),
                    //new Claim(ClaimTypes.Role, user. ?? "User"),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, new DateTimeOffset(now).ToUnixTimeSeconds().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? "Unknown"),
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = now.AddHours(1),
                    IssuedAt = now,
                    Issuer = _jwtOptions.CurrentValue.Issuer,
                    Audience = _jwtOptions.CurrentValue.Audience,
                    SigningCredentials = new SigningCredentials(encodedKey, SecurityAlgorithms.HmacSha256)
                };
                SecurityToken securityToken = jwtHandler.CreateToken(tokenDescriptor);
                string token = jwtHandler.WriteToken(securityToken);

                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating JWT token for user {UserId}", user.Id);
                throw;
            }
        }
    }
}
