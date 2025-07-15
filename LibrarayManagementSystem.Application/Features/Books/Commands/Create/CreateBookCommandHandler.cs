using LibrarayManagementSystem.Application.Features.Users;
using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ResultResponse<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IBookRepository bookRepository,
            ILogger<CreateBookCommandHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultResponse<BookDto>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newBook = request.ToEntity();
                var addResult = await _bookRepository.CreateAsync(newBook, cancellationToken);
                 var saveChanges = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (saveChanges > 0)
                {
                    _logger.LogInformation("Book with ISBN {ISBN} created successfully", newBook.ISBN);
                    return ResultResponse<BookDto>.Success(newBook.ToDto(), HttpStatusCode.Created, "Book created successfully");
                }
                else
                {
                    _logger.LogError("Failed to create book with ISBN {ISBN}", newBook.ISBN);
                    return ResultResponse<BookDto>.Failure(null, new Error("500", "Failed to create book"), HttpStatusCode.InternalServerError, "Failed to create book");
                }
            }
            catch (Exception e)
            {
                return ResultResponse<BookDto>.Failure(new(), new Error("500", "Something went wrong"), HttpStatusCode.InternalServerError);

            }
        }
    }
}
