using FluentValidation;
using LibrarayManagementSystem.Application.Features.Books;
using LibrarayManagementSystem.Application.Features.Books.Commands.Create;
using LibrarayManagementSystem.Application.Response;
using LibraryManagementSystem.WebApi.ApiModels.Request;
using LibraryManagementSystem.WebApi.Controllers;
using LibraryManagementSystem.WebApi.Extensions.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace LibraryManagementSystem.WebApi.Tests.Controllers
{
    public class BooksControllerTests
    {
        //private readonly Mock<ISender> _senderMock = new();
        //private readonly Mock<IValidator<CreateBookCommand>> _createBookValidatorMock = new();
        //private readonly BooksController _controller;

        //public BooksControllerTests()
        //{
        //    _controller = new BooksController(_senderMock.Object);
        //}

        //[Fact]
        //public async Task CreateBook_ReturnsOk_WhenValid()
        //{
        //    // Arrange
        //    var request = new CreateBookRequest { Title = "Test Book", Author = "Peterson" ,ISBN = "9781234567890", PublishedDate = "2000-09-16"};
        //    var command = request.ToCommand("Test User");

        //    _createBookValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateBookCommand>(), It.IsAny<CancellationToken>()))
        //                  .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        //    var resultResponse = ResultResponse<BookDto>.Success(new BookDto { Title = request.Title }, HttpStatusCode.OK);
        //    _senderMock.Setup(s => s.Send(It.IsAny<CreateBookCommand>(), It.IsAny<CancellationToken>()))
        //               .ReturnsAsync(resultResponse);

        //    // Act
        //    var result = await _controller.Create(request, _createBookValidatorMock.Object);

        //    // Assert
        //    var objectResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal((int)HttpStatusCode.Created, objectResult.StatusCode);
        //    Assert.Equal(resultResponse, objectResult.Value);
        //}

        //[Fact]
        //public async Task CreateBook_ReturnsBadRequest_WhenValidationFails()
        //{
        //    // Arrange
        //    var request = new CreateBookRequest { Title = "", ISBN = "invalid", Author = "Mark", PublishedDate = ""};
        //    var command = request.ToCommand("Test User");

        //    var validationResult = new FluentValidation.Results.ValidationResult(new List<FluentValidation.Results.ValidationFailure>
        //{
        //    new("Title", "Title is required")
        //});

        //    _createBookValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateBookCommand>(), It.IsAny<CancellationToken>()))
        //                  .ReturnsAsync(validationResult);

        //    // Act
        //    var result = await _controller.Create(request, _createBookValidatorMock.Object);

        //    // Assert
        //    var objectResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(400, objectResult.StatusCode);
        //}


    }
}
