using System.Collections.Generic;

namespace AuthenticationPortal.Contracts
{
    public class CustomErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ErrorInfo> Info { get; set; }
    }

}
