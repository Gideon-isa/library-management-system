using FluentValidation.Results;
using LibrarayManagementSystem.Application.Response;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Presentation.Extensions
{
    public static class ValidationErrorExtension
    {
        public static (CustomValidationResult<T> result, int statusCode) ToErrorMessage<T>(
            this List<ValidationFailure> validationFailures, T cmd) where T : IResponseData
        {
            CustomValidationResult<T> result = new CustomValidationResult<T>
            {
                Data = cmd,

                Message = validationFailures.Select(m => m.ErrorMessage).FirstOrDefault()?.ToString() ?? string.Empty,

                StatusCode = ConvertStatusCode(validationFailures.Select(u => u.ErrorCode).FirstOrDefault()!),

                IsSuccess = validationFailures.Count <= 0,

                Errors = [.. validationFailures.Select(m => new CustomErrorMessage
                {
                    PropertyName = m.PropertyName,
                    ErrorMessage = m.ErrorMessage,
                })],
            };

            int statusCode = result.StatusCode;

            return (result, statusCode);
        }


        private static int ConvertStatusCode(string statusCode)
        {
            LoggerFactory logger = new LoggerFactory();
            ILogger log = logger.CreateLogger(typeof(ValidationErrorExtension).Name);
            int code = 0;
            try
            {
                code = int.Parse(statusCode);
            }
            catch (Exception e)
            {
                log.LogError($"Unable to parse Status Code {statusCode} to an int", e.Message);
            }
            Console.WriteLine(code);
            return code;
        }
    }

    public class CustomValidationResult<T> where T : IResponseData
    {
        public T? Data { get; set; } 
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<CustomErrorMessage>? Errors { get; set; } = [];
    }

    public class CustomErrorMessage
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    //public class UserData
    //{
    //    public string FirstName { get; set; } = string.Empty;
    //    public string LastName { get; set; } = string.Empty;
    //    public string Email { get; set; } = string.Empty;
    //}
}

