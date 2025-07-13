using FluentValidation;
using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Options.Jwt;
using LibrarayManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace LibrarayManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) 
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly))
                .AddValidatorsFromAssembly(assembly);
            services.AddScoped<IJwtService, JwtService>();
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Section));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtOptions:SigningKey"]!)),
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JwtOptions:Issuer"]!,
                    ValidateAudience = true,
                    ValidAudience = configuration["JwtOptions:Audience"]!,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    RoleClaimType = ClaimTypes.Role,
                };
            });
                
            return services;
        }
    }
}
