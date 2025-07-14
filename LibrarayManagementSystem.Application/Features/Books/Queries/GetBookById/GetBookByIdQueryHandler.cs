using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibrarayManagementSystem.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, ResultResponse<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetBookByIdQueryHandler> _logger;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, ILogger<GetBookByIdQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<ResultResponse<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);
                if (user is not null)
                {
                    _logger.LogInformation("Details of book {@Id} retrieved", user.Id);
                    return ResultResponse<BookDto>.Success(user.ToDto(), System.Net.HttpStatusCode.OK, "book retrieved successfully");
                }
                _logger.LogInformation("Details of book {@Id} was does not exits", user?.Id);
                return ResultResponse<BookDto>.Failure(new BookDto(), new Error("500", "book with Id does not exists"),
                    System.Net.HttpStatusCode.OK, "book not retrieved");

            }
            catch (Exception)
            {
                return ResultResponse<BookDto>.Failure(new BookDto(), new Error("500", "unable to retrieve book"),
                    System.Net.HttpStatusCode.InternalServerError, "something went wrong");
            }
        }
    }
}
