using FluentValidation;
using LibrarayManagementSystem.Application.Features.Books;
using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.WebApi.Extensions.Users;
using LibraryManagementSystem.WebApi.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Controllers
{

    [ApiController]
    [Authorize]
    public abstract class ApiBaseController : ControllerBase
    {
        protected async Task<IActionResult> ValidateAndSendAsync<TCommand>(
            TCommand command,
            IValidator<TCommand> validator, 
            ISender sender, 
            IControllerService controllerService, 
            CancellationToken token) where TCommand : IResponseData
        {
            var (validationResult, statusCode) = await controllerService.ProcessRequestAsync(command, validator, token);

            if (validationResult.IsSuccess is false)
            { 
                return StatusCode(statusCode, validationResult);
            }
            return null;
        }

        //protected async Task<IActionResult> SendQueryAsync<TQuery>(
        //    TQuery query,
        //    ISender sender,
        //    IControllerService controllerService,
        //    CancellationToken token) where TQuery : IResponseData
        //{
        //    var (validationResult, statusCode) = await controllerService.ProcessRequestAsync(query, validator, token);
        //    if (validationResult.IsSuccess is false)
        //    {
        //        return StatusCode(statusCode, validationResult);
        //    }
        //    var result = await sender.Send(query, token);
        //    return StatusCode(statusCode, result);
        //}

        //protected async Task<IActionResult> SendQueryAsync<TQuery, TResponse>(TQuery query, ISender sender, CancellationToken token)
        //    where TQuery : IRequest<TResponse> where TResponse : 
        //{

        //    var result = await sender.Send(query, token);
        //    return StatusCode(result.StatusCode, result);
        //}

        //public IBookCommand BuildCommand<IBookRequest, IBookCommand>(IBookRequest request, Func<IBookRequest, string, IBookCommand> mapper)
        //{
        //    var loginUser = User.GetFullName();
        //    return mapper(request, loginUser!);
        //}
    }
}
   