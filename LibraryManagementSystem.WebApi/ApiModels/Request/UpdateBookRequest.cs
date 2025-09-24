using Azure.Core;
using LibrarayManagementSystem.Application.Features.Books.Commands.Update;
using LibraryManagementSystem.WebApi.Extensions.Users;
using System.Security.Claims;

namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public class UpdateBookRequest : IBookRequest<UpdateBookCommand>
    {
        public required string Title { get; set; } = string.Empty;
        public required string Author { get; set; } = string.Empty;
        public required string ISBN { get; set; } = string.Empty;
        public required string PublishedDate { get; set; }

        //public UpdateBookCommand ToCommand(ClaimsPrincipal claimsPrincipal, int bookId)
        //{
        //    return new UpdateBookCommand
        //    {
        //        Id = bookId,
        //        Title = this.Title,
        //        Author = this.Author,
        //        ISBN = this.ISBN,
        //        PublishedDate = this.PublishedDate,
        //        ModifiedBy = claimsPrincipal.GetFullName()!
        //    };
        //}
    }
}
