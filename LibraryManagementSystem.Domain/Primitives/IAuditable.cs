namespace LibraryManagementSystem.Domain.Primitives
{
    public interface IAuditable
    {
        public DateTime CreatedOn { get;  }
        public DateTime? ModifiedOn { get; }
        public string? ModifiedBy { get; }
    }
}
