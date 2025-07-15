using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ResultResponse<bool>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteBookCommandHandler> _logger;

        public DeleteBookCommandHandler(IBookRepository bookRepository, 
            ILogger<DeleteBookCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultResponse<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);
                if (book is null)
                {
                    _logger.LogWarning("Book with ID {Id} not found", request.Id);
                    return ResultResponse<bool>.Failure(false, new Error("404", "Book not found"), HttpStatusCode.NotFound, "Book not found");
                }
                var isMarkedDeleted = await _bookRepository.DeleteAsync(book, cancellationToken); 
                if (isMarkedDeleted.State is EntityState.Deleted)
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation("Book with ID {Id} deleted successfully", request.Id);
                    return ResultResponse<bool>.Success(true, HttpStatusCode.OK, "Book deleted successfully");
                }
                else
                {
                    _logger.LogWarning("Failed to delete book with ID {Id}", request.Id);
                    return ResultResponse<bool>.Failure(false, new Error("500", "Failed to delete book"), HttpStatusCode.InternalServerError, "Failed to delete book");
                }   

            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while deleting book with ID {Id}", request.Id);
                return ResultResponse<bool>.Failure(false, new Error("500", "An error occurred while deleting book"), HttpStatusCode.InternalServerError, "An error occurred while deleting book");
            }
        }
    }
}
