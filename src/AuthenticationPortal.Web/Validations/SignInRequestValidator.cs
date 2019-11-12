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
            .WithErrorCode(ResourceHelper.getErrorCode("Null_Field_Error"))
            .WithMessage(ResourceHelper.getErrorData("Null_Field_Error", "Username"))
            .NotEmpty()
            .WithErrorCode(ResourceHelper.getErrorCode("Blank_Field_Error"))
            .WithMessage(ResourceHelper.getErrorData("Blank_Field_Error", "Username"));

            RuleFor(x => x.Password)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ResourceHelper.getErrorCode("Null_Field_Error"))
            .WithMessage(ResourceHelper.getErrorData("Null_Field_Error", "Password"))
            .NotEmpty()
            .WithErrorCode(ResourceHelper.getErrorCode("Blank_Field_Error"))
            .WithMessage(ResourceHelper.getErrorData("Blank_Field_Error", "Password"));
        }
    }
}
