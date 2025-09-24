using LibrarayManagementSystem.Application.Features.Books.Commands;
using System.Security.Claims;

namespace LibraryManagementSystem.WebApi.ApiModels.Request
{
    public interface IBookRequest<IBookCommand>
    {
        //public IBookCommand ToCommand(ClaimsPrincipal claimsPrincipal, int id);
    }
}
