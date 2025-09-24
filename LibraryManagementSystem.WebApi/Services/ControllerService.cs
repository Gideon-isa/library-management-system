using FluentValidation;
using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Services
{
    public class ControllerService : IControllerService
    {
        public async Task<(CustomValidationResult<TCommand> result, int statusCode)> ProcessRequestAsync<TCommand>(
            TCommand command, 
            IValidator<TCommand> validator, CancellationToken cancellationToken) 
            where TCommand : IResponseData
        {
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                var customError = validationResult.Errors.ToErrorMessage(command);
                return customError;
            }
            return (new CustomValidationResult<TCommand> { IsSuccess = true}, StatusCodes.Status200OK);
        }
    }
}
