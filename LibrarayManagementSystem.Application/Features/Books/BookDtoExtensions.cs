using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Features.Books
{
    public  static class BookDtoExtensions
    {
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
            };
        }
        //public static IEnumerable<BookDto> ToDtos(this IEnumerable<Book> books)
        //{
        //    return books.Select(book => book.ToDto());
        //}
    }
}
