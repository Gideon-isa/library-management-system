using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Repository
{
    public interface IBookRepository
    {
        Task<Book?> CreateAsync(Book book, CancellationToken cancellationToken);
        Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetAllAsync(CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksByAuthorAsync(string author, CancellationToken cancellationToken);
        Task<Book?> GetByISBNAsync(string isbn, CancellationToken cancellationToken);
        Task<Book?> UpdateAsync(Book book, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    }
}
