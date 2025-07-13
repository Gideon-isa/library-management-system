using FluentValidation;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Signup
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .WithErrorCode("400")
                .MinimumLength(2)
                .WithMessage("Initials are not allowed for First name")
                .WithErrorCode("400");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .WithErrorCode("400")
                .MinimumLength(2)
                .WithMessage("Initials are not allowed for Last name")
                .WithErrorCode("400");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .WithErrorCode("400")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Email is not valid")
                .WithErrorCode("400");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .WithErrorCode("400")
                .Equal(u => u.ReEnteredPassword)
                .WithMessage("Passwords do not match")
                .WithErrorCode("400");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("username is required")
                .WithErrorCode("400")
                .Must(u => !u.Contains('@'))
                .WithMessage("username should not contain the '@' character ")
                .WithErrorCode("400");
        }

    }
}
