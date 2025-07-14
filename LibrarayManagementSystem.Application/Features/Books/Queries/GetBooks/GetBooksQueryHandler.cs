using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace LibrarayManagementSystem.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, ResultResponse<List<BookDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetBooksQueryHandler> _logger;
        public GetBooksQueryHandler(IBookRepository bookRepository, ILogger<GetBooksQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<ResultResponse<List<BookDto>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Book, BookDto>> bookQuery = GetBooksQuery.ProjectToDto();
                IQueryable<Book> query = await _bookRepository.GetBooksAsync(request.Search, cancellationToken);
                var booksDtos = await query.Select(bookQuery).ToListAsync(cancellationToken);
                return ResultResponse<List<BookDto>>.Success(booksDtos, System.Net.HttpStatusCode.OK, "Books retrieved successfully");

            }
            catch (Exception)
            {

                throw;
            }

            
        }

    }
}
