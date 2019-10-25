using FluentValidation;

namespace AuthenticationPortal.Web.Validations
{
    public class SignInRequestValidator : AbstractValidator<Contracts.SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("400")
            .WithMessage("Username cannot be Blank");

            RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithErrorCode("400")
            .WithMessage("Password cannot be blank.")
            .MinimumLength(6)
            .WithErrorCode("400")
            .WithMessage("Invalid Password");
        }
    }
}
