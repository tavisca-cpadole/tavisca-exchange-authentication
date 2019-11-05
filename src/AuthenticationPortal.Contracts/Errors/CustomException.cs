using System.Collections.Generic;
using System.Net;

namespace AuthenticationPortal.Contracts
{
    public class CustomException : BaseException
    {
        public CustomException(HttpStatusCode statusCode, string message, List<ErrorInfo> info = null) : base(ResourceHelper.getErrorData(message), int.Parse(ResourceHelper.getErrorCode(message)), info, statusCode)
        {
          //  x sabas znKJJsns
        }
    }

}
