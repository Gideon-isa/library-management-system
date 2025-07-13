using System.Net;

namespace LibrarayManagementSystem.Application.Response
{
    public class ResultResponse<TValue> : Result
    {
        private readonly TValue? _value;
        private readonly string? _message;
        private readonly int _statusCode;

        protected internal ResultResponse(TValue? value, bool isSuccess, Error error, HttpStatusCode statusCode,
            string? message = default)
            : base(isSuccess, error)
        {
            _value = value;
            _message = message;
            _statusCode = (int)statusCode;
        }

        public TValue Data => IsSuccess ? _value! : default!;
        public string Message => _message ?? "";
        public int StatusCode => _statusCode;

        public static ResultResponse<TValue> Success(TValue value, HttpStatusCode statusCode, string? message = default) 
            => new ResultResponse<TValue>(value, true, Error.None, statusCode, message);

        public static ResultResponse<TValue> Failure(TValue value, Error error, HttpStatusCode statusCode, string? message = default) 
            => new ResultResponse<TValue>(value, false, error, statusCode, message);
    }
}
