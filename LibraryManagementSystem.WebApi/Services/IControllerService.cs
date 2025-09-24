using FluentValidation;
using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Services
{
    public interface IControllerService
    {
        Task<(CustomValidationResult<TCommand> result, int statusCode)> ProcessRequestAsync<TCommand>(
            TCommand command,
            IValidator<TCommand> validator,
            CancellationToken cancellationToken) where TCommand : IResponseData;
    }
}
