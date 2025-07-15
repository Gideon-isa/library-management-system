using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Infrastructure.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(ApplicationDbContext context, ILogger<BookRepository> logger)
        {
            _dbcontext = context;
            _logger = logger;
        }
        public async Task<EntityEntry<Book>> CreateAsync(Book book, CancellationToken cancellationToken)
        {
            var saveResult = await _dbcontext.Books.AddAsync(book);
            return saveResult;
        }

        public Task<bool> DeleteAsync(Book book, CancellationToken cancellationToken)
        {
            var deletedBookEntry = _dbcontext.Books.Remove(book);
            var isMarkedForDeletion = deletedBookEntry.State == EntityState.Deleted;
            return Task.FromResult(isMarkedForDeletion);
        }

        public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Book>> GetBooksAsync(string? search, CancellationToken cancellationToken)
        {
            var query = _dbcontext.Books.Where(s => search == null || s.Title.Contains(search) || s.Author.Contains(search));
            return Task.FromResult(query);
        }

        public Task<IQueryable<Book>> GetBooksByAuthorAsync(string author, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbcontext.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public Task<Book?> GetByISBNAsync(string isbn, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<EntityEntry<Book>> UpdateAsync(Book book, CancellationToken cancellationToken)
        {
           var updatedBookEntry = _dbcontext.Books.Update(book);
           return Task.FromResult(updatedBookEntry);

        }
    }
}
