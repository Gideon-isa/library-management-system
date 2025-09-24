using LibrarayManagementSystem.Application;
using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Features.Books.Commands;
using LibraryManagementSystem.Infrastructure;
using LibraryManagementSystem.Infrastructure.Database.Data;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using LibraryManagementSystem.WebApi.Controllers;
using LibraryManagementSystem.WebApi.Extensions.ApplicationExtension;
using LibraryManagementSystem.WebApi.Middleware;
using LibraryManagementSystem.WebApi.Services;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adding the Infrastructure services
builder.Services.AddInfrastructureServices(builder.Configuration);

// 
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddScoped<IControllerService, ControllerService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new ProducesResponseTypeConvention());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management System API",
        Version = "v1"
    });
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter Bearer token"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }

            }, Array.Empty<string>()
        }
    });
});

builder.Services.AddApplicationVersioning();
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});
var app = builder.Build();

// seed data to the database'
await app.SeedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
