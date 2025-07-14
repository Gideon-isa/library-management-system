using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace LibrarayManagementSystem.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<ResultResponse<List<BookDto>>>, IResponseData
    {
        public string? Search { get; set; } = string.Empty;

        public static Expression<Func<Book, BookDto>> ProjectToDto() => book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PublishedDate = book.PublishedDate,
            CreatedBy = book.CreatedBy,
            CreatedOn = book.CreatedOn,
            ModifiedOn = book.ModifiedOn,
            ModifiedBy = book.ModifiedBy
        };
    }
}
