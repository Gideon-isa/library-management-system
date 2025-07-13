using FluentValidation;

namespace LibrarayManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("id can not be empty")
                .WithErrorCode("400");
        }
    }
}
