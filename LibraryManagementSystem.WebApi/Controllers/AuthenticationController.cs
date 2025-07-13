using FluentValidation;
using LibrarayManagementSystem.Application.Features.Users.Commands.Login;
using LibrarayManagementSystem.Application.Features.Users.Commands.Signup;
using LibraryManagementSystem.Presentation.Extensions;
using LibraryManagementSystem.Presentation.Extensions.Users;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(ISender sender) : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(
            [FromBody] CreateUserRequest request, 
            [FromServices] IValidator<CreateUserCommand> validator, 
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
            return result.IsSuccess ?
            CreatedAtAction(nameof(GetUserById), new { id = result.Data.Id }, result )
            : StatusCode(result.StatusCode, result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> login(
            [FromBody] LoginUserRequest request,
            [FromServices] IValidator<LoginUserCommand> validator,
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

        [AllowAnonymous]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(
            [FromRoute] Guid id, [FromServices] IValidator<GetUserByIdQuery> validator, 
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
            return null;
        }
    }
}
