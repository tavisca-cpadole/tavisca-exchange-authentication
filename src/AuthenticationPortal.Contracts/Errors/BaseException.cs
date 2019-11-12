using System;
using System.Collections.Generic;
using System.Net;

namespace AuthenticationPortal.Contracts
{
    [Serializable]
    public class BaseException : Exception
    {
        public int Code { get; }
        public string Message { get; }
        public List<ErrorInfo> Info { get; }
        public HttpStatusCode StatusCode { get; }
        public BaseException(string message, int code, List<ErrorInfo> info, HttpStatusCode statusCode) : base(message)
        {
            Code = code;
            Message = message;
            Info = info;
            StatusCode = statusCode;
        }
        public BaseException(string message, int code, HttpStatusCode statusCode) : base(message)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
