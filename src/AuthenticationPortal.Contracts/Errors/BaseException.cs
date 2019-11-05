using System;
using System.Collections.Generic;
using System.Net;

namespace AuthenticationPortal.Contracts
{
    [Serializable]
    public class BaseException : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ErrorInfo> Info { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public BaseException(string message, int code, List<ErrorInfo> info, HttpStatusCode statusCode) : base(message)
        {
            Code = code;
            Message = message;
            Info = info;
            StatusCode = statusCode;
        }
    }
}
