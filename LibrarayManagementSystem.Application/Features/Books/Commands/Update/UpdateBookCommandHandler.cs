using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResultResponse<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<ResultResponse<BookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);
                if (book is null)
                {
                    _logger.LogWarning("Book with ID {Id} not found", request.Id);
                    return ResultResponse<BookDto>.Failure(null, new Error("404", "Book not found"), HttpStatusCode.NotFound, "Book not found");
                }

                // Update the book details
                book.UpdateBook(
                    request.Title, 
                    request.Author, 
                    request.ISBN,
                    DateTime.Parse(request.PublishedDate), 
                    "fullname");


                var updateEntry = await _bookRepository.UpdateAsync(book, cancellationToken);
                if (updateEntry.State is EntityState.Modified)
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation("Book with ID {Id} updated successfully", request.Id);
                    return ResultResponse<BookDto>.Success(book.ToDto(), HttpStatusCode.OK, "Book updated successfully");
                }
                return ResultResponse<BookDto>.Failure(null, new Error("500", "Failed to update book"), HttpStatusCode.InternalServerError, "Failed to update book");

            }
            catch (DbUpdateException e)
            {
                var message = e.InnerException?.Message.ToLower();
                if (e.InnerException is not null && message!.Contains("duplicate key")
                    || message!.Contains("unique") || message.Contains("constraint"))
                {
                    return ResultResponse<BookDto>.Failure(null, new Error("409", "Book with this ISBN already exists"), HttpStatusCode.Conflict, "Book with this ISBN already exists");
                }
                _logger.LogError(e, "Database error occurred while creating book with ISBN {ISBN}", request.ISBN);
                throw new Exception("Database error occurred while creating book", e);
            }
            catch (Exception e)
            {
                return ResultResponse<BookDto>.Failure(new(), new Error("500", "Something went wrong"), HttpStatusCode.InternalServerError);
            }
        }
    }
}
