﻿using System.Net;

namespace AuthenticationPortal.Contracts
{
    public class TokenAuthenticationResponse
    {
        public HttpStatusCode AuthenticationStatusCode { get; set; }
    }
}
