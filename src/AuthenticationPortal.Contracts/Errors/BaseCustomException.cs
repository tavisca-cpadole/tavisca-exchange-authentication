using System;
using System.Net;

namespace Authentication
{
    [Serializable]
    public class BaseCustomException : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public BaseCustomException(string message, int code) : base(message)
        {
            Code = code;
            Message = message;
        }
    }

    public class CustomErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class UnauthorizedCustomException : BaseCustomException
    {
        public UnauthorizedCustomException(string message) : base(message, (int)HttpStatusCode.Unauthorized)
        {
        }
    }

    public class InvalidTokenException : BaseCustomException
    {
        public InvalidTokenException(string message) : base(message, (int)HttpStatusCode.Unauthorized)
        {
        }
    }

    public class MissingHeaderException : BaseCustomException
    {
        public MissingHeaderException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }

    public class InvalidRequestException : BaseCustomException
    {
        public InvalidRequestException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }

}
