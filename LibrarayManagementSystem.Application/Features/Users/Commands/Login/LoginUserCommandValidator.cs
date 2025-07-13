using FluentValidation;

namespace LibrarayManagementSystem.Application.Features.Users.Commands.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.UsernameOrEmail)
                .NotEmpty()
                .WithMessage("email or username is required")
                .WithErrorCode("400")
                .MinimumLength(2)
                .WithMessage("Initials are not allowed for First name")
                .WithErrorCode("400");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("password is required")
                .WithErrorCode("400");
        }
    }
}
