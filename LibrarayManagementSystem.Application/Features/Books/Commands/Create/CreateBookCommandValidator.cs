using FluentValidation;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
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
                .NotEmpty()
                .WithMessage("ISBN is required.")
                .WithErrorCode("400")
                .MaximumLength(17)
                .WithMessage("ISBN is not valid.")
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
