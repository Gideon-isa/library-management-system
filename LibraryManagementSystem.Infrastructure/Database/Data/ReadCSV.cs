using CsvHelper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Database.Constants;
using LibraryManagementSystem.Infrastructure.Database.Extensions;
using System.Globalization;
using System.Reflection;

namespace LibraryManagementSystem.Infrastructure.Database.Data
{
    internal sealed class ReadCSV
    {
        public static List<Book> ReadCsvFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resource = DataBaseConstants.Data.BookCsvResource;
            using var stream = assembly.GetManifestResourceStream(resource);
            if (stream is null)
            {
                throw new FileNotFoundException($"Resource '{resource}' not found in assembly '{assembly.FullName}'.");
            }

            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<BookModel>();

            var books = records.Select(r => r.ToDomainEntity()).ToList();
            return books;
        }
    }
}
