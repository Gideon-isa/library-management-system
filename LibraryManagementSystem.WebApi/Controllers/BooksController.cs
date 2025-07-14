using FluentValidation;
using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibraryManagementSystem.Presentation.Extensions;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using LibraryManagementSystem.WebApi.Extensions.Books;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    //[Authorize]
    public class BooksController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest request, 
            [FromServices] IValidator<CreateBookCommand> validator, 
            CancellationToken cancellationToken = default)
        {
            var cmd = request.ToCommand();
            var validationResult = await validator.ValidateAsync(cmd, cancellationToken);
            if (!validationResult.IsValid)
            {
                var customError = validationResult.Errors.ToErrorMessage(cmd);
                return StatusCode(customError.statusCode, customError.result);
            }
            var result = await sender.Send(cmd, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetBooks([FromQuery] BooksQueryRequest query, CancellationToken cancellationToken)
        //{
        //    query.search ??= query.search?.Trim().ToLower();
        //}
    }
}
