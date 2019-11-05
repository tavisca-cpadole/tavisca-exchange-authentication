using AuthenticationPortal.Contracts;
using FluentValidation;

namespace AuthenticationPortal.Web
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.Username)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ResourceHelper.getErrorCode("Null Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Null Field Error", "Username"))
            .NotEmpty()
            .WithErrorCode(ResourceHelper.getErrorCode("Blank Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Blank Field Error", "Username"));

            RuleFor(x => x.Password)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ResourceHelper.getErrorCode("Null Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Null Field Error", "Password"))
            .NotEmpty()
            .WithErrorCode(ResourceHelper.getErrorCode("Blank Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Blank Field Error", "Password"));
        }
    }
}
