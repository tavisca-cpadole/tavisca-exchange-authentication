using System;

namespace AuthenticationPortal.Contracts
{
    [Serializable]
    public class BaseException : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public BaseException(string message, int code) : base(message)
        {
            Code = code;
            Message = message;
        }
    }
}
