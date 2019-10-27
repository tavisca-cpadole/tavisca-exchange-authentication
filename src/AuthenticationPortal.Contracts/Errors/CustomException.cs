namespace AuthenticationPortal.Contracts
{
    public class CustomException : BaseException
    {
        public CustomException(int code) : base(CustomErrorCodes.getErrorMessage(code), code)
        {
        }
    }

}
