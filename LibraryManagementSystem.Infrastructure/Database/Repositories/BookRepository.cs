using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Infrastructure.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(ApplicationDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> CreateAsync(Book book, CancellationToken cancellationToken)
        {
            await _context.Books.AddAsync(book);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Book>> GetBooksByAuthorAsync(string author, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetByISBNAsync(string isbn, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> UpdateAsync(Book book, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
