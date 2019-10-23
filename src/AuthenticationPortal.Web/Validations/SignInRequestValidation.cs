using Authentication;
using FluentValidation;

namespace AuthenticationPortal.Web.Validations
{
    public class SignInRequestValidation : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidation()
        {
            RuleFor(x => x.Username)
           .NotNull()
           .WithMessage("Username  cannot be blank.");

            RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("Password  cannot be blank.")
            .Length(6)
            .WithMessage("Invalid Password");

        }
    }
}
