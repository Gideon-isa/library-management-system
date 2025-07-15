using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Domain.Repository
{
    public interface IBookRepository
    {
        Task<EntityEntry<Book>> CreateAsync(Book book, CancellationToken cancellationToken);
        Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksAsync(string? search, CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksByAuthorAsync(string author, CancellationToken cancellationToken);
        Task<Book?> GetByISBNAsync(string isbn, CancellationToken cancellationToken);
        Task<EntityEntry<Book>> UpdateAsync(Book book, CancellationToken cancellationToken);
        Task<EntityEntry<Book>> DeleteAsync(Book user, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    }
}
