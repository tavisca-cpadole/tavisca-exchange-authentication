using AuthenticationPortal.Contracts;
using FluentValidation;

namespace AuthenticationPortal.Web
{
    public class TokenAuthenticationRequestValidator : AbstractValidator<TokenAuthenticationRequest>
    {
        public TokenAuthenticationRequestValidator()
        {
            RuleFor(x => x.AccessToken)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ResourceHelper.getErrorCode("Null Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Null Field Error", "Access Token"))
            .NotEmpty()
            .WithErrorCode(ResourceHelper.getErrorCode("Blank Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Blank Field Error", "Access Token"));

            RuleFor(x => x.UserId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ResourceHelper.getErrorCode("Null Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Null Field Error", "UserId"))
            .NotEmpty()
            .WithErrorCode(ResourceHelper.getErrorCode("Blank Field Error"))
            .WithMessage(ResourceHelper.getErrorData("Blank Field Error", "UserId"));
        }
    }
}
