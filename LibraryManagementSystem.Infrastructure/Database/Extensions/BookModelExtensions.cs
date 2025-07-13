using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Database.Data;

namespace LibraryManagementSystem.Infrastructure.Database.Extensions
{
    internal static class BookModelExtensions
    {
        public static Book ToDomainEntity(this BookModel bookModel)
        {
            return Book.CreateBook(bookModel.Title, bookModel.Author, bookModel.ISBN, bookModel.PublishedDate, "Admin");

        }
    }
}
