using AuthenticationPortal.Contracts;
using FluentValidation;
using System.Collections.Generic;
using System.Net;

namespace AuthenticationPortal.Web
{
    public static class EnsureValidator
    {
        public static void EnsureValid<SignInRequest>(this IValidator<SignInRequest> validator, SignInRequest request)
        {
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid == false)
            {
                List<ErrorInfo> _info = new List<ErrorInfo>();
                foreach (var error in validationResult.Errors)
                {
                    _info.Add(new ErrorInfo() { Code = error.ErrorCode, Message = error.ErrorMessage });
                }
                throw new CustomException(HttpStatusCode.BadRequest, "Validation Error", _info);
            }
        }
    }
}
