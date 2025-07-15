using FluentValidation;
using System.Text.RegularExpressions;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Update
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Author is required.")
                .WithErrorCode("400")
                .MaximumLength(200)
                .WithMessage("Author must not exceed 200 characters.")
                .WithErrorCode("400")
                .MinimumLength(3)
                .WithMessage("Author name can not be less than 3 characters")
                .WithErrorCode("400");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Tile is required.")
                .WithErrorCode("400")
                .MaximumLength(200)
                .WithMessage("Title must not exceed 200 characters.")
                .WithErrorCode("400")
                .MinimumLength(3)
                .WithMessage("Title name can not be less than 3 characters")
                .WithErrorCode("400");

            RuleFor(x => x.ISBN)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("ISBN is required.")
                .WithErrorCode("400")
                .Must(IsbnValidator.IsValidIsbnFormat)
                .WithMessage("ISBN is not valid.")
                .WithErrorCode("400")
                .MaximumLength(20)
                .WithMessage("ISBN must not exceed 20 characters.")
                .WithErrorCode("400");

            RuleFor(x => x.PublishedDate)
                .NotEmpty()
                .WithMessage("Published Date is required.")
                .WithErrorCode("400")
                .Must(x => DateTime.TryParse(x, out _))
                .WithMessage("Published date must be a valid date")
                .WithErrorCode("400");
        }
    }
}
