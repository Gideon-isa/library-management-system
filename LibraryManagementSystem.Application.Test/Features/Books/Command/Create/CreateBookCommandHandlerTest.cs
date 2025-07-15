using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace LibraryManagementSystem.Application.Test.Features.Books.Command.Create
{
    public class CreateBookCommandHandlerTest
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly Mock<ILogger<CreateBookCommandHandler>> _loggerMock = new();

        private readonly CreateBookCommandHandler _handler;

        public CreateBookCommandHandlerTest()
        {
            _handler = new CreateBookCommandHandler(
                _bookRepositoryMock.Object,
                _loggerMock.Object,
                _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsSuccess_WhenBookIsCreated()
        {
            // Arrange
            var command = new CreateBookCommand { Title = "Test", ISBN = "9781234567890", Author = "Dennis", PublishedDate = "2022-04-04"};
            var entity = command.ToEntity();

            _bookRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity); 

            _unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
            Assert.True(result.IsSuccess);
            Assert.Equal(command.ISBN, result.Data?.ISBN);
        }

        [Fact]
        public async Task Handle_ReturnsConflict_WhenDuplicateISBN()
        {
            // Arrange
            var command = new CreateBookCommand { Title = "Test", ISBN = "9781234567890", Author = "Dennis", PublishedDate = "2022-04-04" };

            var innerEx = new Exception("duplicate key error");
            var dbEx = new DbUpdateException("Error", innerEx);

            _bookRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(dbEx);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal((int)HttpStatusCode.Conflict, result.StatusCode);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task Handle_ReturnsInternalServerError_WhenSaveChangesIsZero()
        {
            // Arrange
            var command = new CreateBookCommand {Title = "Test", ISBN = "9781234567890", Author = "Dennis", PublishedDate = "2022-04-04" };
            var entity = command.ToEntity();

            _bookRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity); // dummy

            _unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(0); // simulate failure

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task Handle_ReturnsInternalServerError_OnUnexpectedException()
        {
            // Arrange
            var command = new CreateBookCommand { ISBN = "9781234567890" };

            _bookRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Unexpected"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.False(result.IsSuccess);
        }
    }
}
