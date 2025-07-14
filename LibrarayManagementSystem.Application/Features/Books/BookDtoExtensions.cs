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

        public static BookDtos BookDtos(this List<BookDto> bookDtos, int pageNumber, int pageSize, int totalCount)
        {
            return new BookDtos
            {
                Books = bookDtos,
                Page = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
            };
        }
    }
}
