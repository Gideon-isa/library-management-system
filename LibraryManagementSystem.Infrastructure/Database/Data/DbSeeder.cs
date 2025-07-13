using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Infrastructure.Database.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<ApplicationDbContext>();
            var result = dbContext.Books.Any();
            if (dbContext.Books.Any())
            {
                return; // Database has already been seeded
            }
            var books = ReadCSV.ReadCsvFile();
            // Ensure the database is created
            await dbContext.Books.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
        }
    }
}
