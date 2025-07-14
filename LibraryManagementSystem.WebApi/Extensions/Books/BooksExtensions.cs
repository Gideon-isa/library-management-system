using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibraryManagementSystem.WebApi.ApiModels.Request;

namespace LibraryManagementSystem.WebApi.Extensions.Books
{
    public static class BooksExtensions
    {
        public static CreateBookCommand ToCommand(this CreateBookRequest request)
        {
            return new CreateBookCommand
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublishedDate = request.PublishedDate
            };
        }

    }
}
