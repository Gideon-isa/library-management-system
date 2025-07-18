﻿using FluentValidation;
using LibrarayManagementSystem.Application.Features.Users.Commands.Login;
using LibrarayManagementSystem.Application.Features.Users.Commands.Signup;
using LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById;
using LibraryManagementSystem.Presentation.Extensions;
using LibraryManagementSystem.Presentation.Extensions.Users;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    [Authorize]
    public class AuthenticationController(ISender sender) : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType(typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType(typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType(typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> GetUserById(
            [FromRoute] Guid id, [FromServices] IValidator<GetUserByIdQuery> validator, 
            CancellationToken cancellationToken = default)
        {
            var cmd = UserExtensions.ToCommand(id);
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
