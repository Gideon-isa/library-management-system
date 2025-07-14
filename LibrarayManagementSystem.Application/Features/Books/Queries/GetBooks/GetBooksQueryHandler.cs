using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace LibrarayManagementSystem.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, ResultResponse<BookDtos>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetBooksQueryHandler> _logger;
        public GetBooksQueryHandler(IBookRepository bookRepository, ILogger<GetBooksQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<ResultResponse<BookDtos>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Book, BookDto>> bookQuery = GetBooksQuery.ProjectToDto();
                IQueryable<Book> query = await _bookRepository.GetBooksAsync(request.Search, cancellationToken);

                int totalCount = await query.CountAsync(cancellationToken);

                var booksDtos = await query
                    .OrderBy(b => b.Id)
                    .Skip((request.PageNumber - 1)* request.PageSize)
                    .Take(request.PageSize)
                    .Select(bookQuery).ToListAsync(cancellationToken);

                var bookResult = booksDtos.BookDtos(request.PageNumber, request.PageSize, totalCount);
                return ResultResponse<BookDtos>.Success(bookResult, System.Net.HttpStatusCode.OK, "Books retrieved successfully");

            }
            catch (Exception)
            {

                throw;
            }

            
        }

    }
}
