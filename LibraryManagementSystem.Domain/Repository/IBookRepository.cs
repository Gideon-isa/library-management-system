using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Domain.Repository
{
    public interface IBookRepository
    {
        Task<bool> CreateAsync(Book book, CancellationToken cancellationToken);
        Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksAsync(string? search, CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksByAuthorAsync(string author, CancellationToken cancellationToken);
        Task<Book?> GetByISBNAsync(string isbn, CancellationToken cancellationToken);
        Task<Book?> UpdateAsync(Book book, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    }
}
