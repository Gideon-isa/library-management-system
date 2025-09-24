using FluentValidation;
using LibrarayManagementSystem.Application.Contracts;
using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibrarayManagementSystem.Application.Features.Books.Commands.Delete;
using LibrarayManagementSystem.Application.Features.Books.Commands.Update;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using LibraryManagementSystem.WebApi.Extensions.Books;
using LibraryManagementSystem.WebApi.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Controllers
{
    [Route("api/books")]
    public class BooksController(ISender sender, IControllerService controllerService, ICurrentUserService currentUserService) : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest request,
            [FromServices] IValidator<CreateBookCommand> validator,
            CancellationToken cancellationToken = default)
        {

            var cmd = request.ToCommand(currentUserService);
            var validation = await ValidateAndSendAsync(cmd, validator, sender, controllerService, cancellationToken);
            if (validation is not null) 
                return validation;
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
            var cmd = BooksExtensions.ToDeleteCommand(id);
            var result = await sender.Send(cmd, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id,
            [FromBody] UpdateBookRequest request,
            [FromServices] IValidator<UpdateBookCommand> validator,
            CancellationToken cancellationToken = default)
        {

            var cmd = request.ToCommand(id, currentUserService);
            var validation = await ValidateAndSendAsync(cmd, validator, sender, controllerService, cancellationToken);
            if (validation is not null)
                return validation;
            var result = await sender.Send(cmd, cancellationToken);
            return StatusCode(result.StatusCode, result);

        }
    }
}
