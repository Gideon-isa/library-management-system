using Azure.Core;
using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibraryManagementSystem.WebApi.Extensions.Users;
using System.Security.Claims;

namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public class CreateBookRequest : IBookRequest<CreateBookCommand>
    {
        public required string Title { get; set; } = string.Empty;
        public required string Author { get; set; } = string.Empty;
        public required string ISBN { get; set; } = string.Empty;
        public required string PublishedDate { get; set; }

        //public CreateBookCommand ToCommand(ClaimsPrincipal claimsPrincipal, int bookId)
        //{
        //    return new CreateBookCommand
        //    {
        //        Title = this.Title,
        //        Author = this.Author,
        //        ISBN = this.ISBN,
        //        PublishedDate = this.PublishedDate,
        //        CreatedBy = claimsPrincipal.GetFullName()!
        //    };
        //}
    }
}
