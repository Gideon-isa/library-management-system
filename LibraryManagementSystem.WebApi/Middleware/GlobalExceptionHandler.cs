using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        IProblemDetailsService _problemDetailsService;
        public GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService;
        }
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path,
                Extensions = { ["requestId"] = httpContext.TraceIdentifier }
            };

            problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

            return _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails,

            });
        }
    }
}
