using AuthenticationPortal.Errors;

namespace Authentication.Errors
{
    public class CustomException : BaseException
    {
        public CustomException(int code) : base(CustomErrorCodes.getErrorMessage(code), code)
        {
        }
    }

}
