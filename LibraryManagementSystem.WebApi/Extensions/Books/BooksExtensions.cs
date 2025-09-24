using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibrarayManagementSystem.Application.Features.Books.Commands.Delete;
using LibrarayManagementSystem.Application.Features.Books.Commands.Update;
using LibrarayManagementSystem.Application.Features.Books.Queries.GetBookById;
using LibrarayManagementSystem.Application.Features.Books.Queries.GetBooks;
using LibraryManagementSystem.WebApi.ApiModels.Request;

namespace LibraryManagementSystem.WebApi.Extensions.Books
{
    public static class BooksExtensions
    {
        public static CreateBookCommand ToCommand(this CreateBookRequest request, ICurrentUserService currentUserService)
        {
            return new CreateBookCommand
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublishedDate = request.PublishedDate,
                CreatedBy = currentUserService.GetFullName()!
            };
        }

        public static UpdateBookCommand ToCommand(this UpdateBookRequest request, int bookId, ICurrentUserService currentUserService)
        {
            return new UpdateBookCommand
            {
                Id = bookId,
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublishedDate = request.PublishedDate,
                ModifiedBy = currentUserService.GetFullName()!
            };
        }

        public static GetBooksQuery ToQuery(this GetBooksQueryRequest request)
        {
            return new GetBooksQuery
            {
               Search = request.Search?.Trim().ToLower(),
               PageNumber = request.PageNumber,
               PageSize = request.PageSize
            };
        }

        public static GetBookByIdQuery ToQuery(int id)
        {
            return new GetBookByIdQuery
            {
                Id = id
            };
        }

        public static DeleteBookCommand ToDeleteCommand(int id)
        {
            return new DeleteBookCommand
            {
                Id = id
            };
        }
    }
}
