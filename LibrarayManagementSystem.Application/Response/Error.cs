namespace LibrarayManagementSystem.Application.Response
{
    public class Error
    {
        private string? Code { get; set; }
        private string? Description { get; set; }

        public Error(string code, string? description = null)
        {
            Code = code;
            Description = description;
        }
        public static readonly Error None = new(string.Empty);
        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}
