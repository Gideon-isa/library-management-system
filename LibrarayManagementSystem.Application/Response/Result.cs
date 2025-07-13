namespace LibrarayManagementSystem.Application.Response
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error) 
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            { 
                throw new ArgumentException("Invalod error", nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }


        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }

}
