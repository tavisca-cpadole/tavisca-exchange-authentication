using Authentication;
using FluentValidation;

namespace AuthenticationPortal.Web.Validations
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.Username)
           .NotNull()
           .WithErrorCode("400")
           .WithMessage("Username cannot be null")
           .NotEmpty()
           .WithErrorCode("400")
           .WithMessage("Username cannot be blank.");

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
