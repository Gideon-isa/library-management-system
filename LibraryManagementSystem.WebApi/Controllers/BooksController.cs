using FluentValidation;
using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibrarayManagementSystem.Application.Features.Books.Commands.Update;
using LibraryManagementSystem.Presentation.Extensions;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using LibraryManagementSystem.WebApi.Extensions.Books;
using MediatR;
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

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] GetBooksQueryRequest queryRequest, CancellationToken cancellationToken)
        {
            var query = queryRequest.ToQuery();
            var result = await sender.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var query = BooksExtensions.ToQuery(id);
            var result = await sender.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBookById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var query = BooksExtensions.ToDeleteCommand(id);
            var result = await sender.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id,
            [FromBody] UpdateBookRequest request,
            [FromServices] IValidator<UpdateBookCommand> validator,
            CancellationToken cancellationToken = default)
        {
            var cmd = request.ToCommand(id);
            var validationResult = await validator.ValidateAsync(cmd, cancellationToken);
            if (!validationResult.IsValid)
            {
                var customError = validationResult.Errors.ToErrorMessage(cmd);
                return StatusCode(customError.statusCode, customError.result);
            }
            var result = await sender.Send(cmd, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
