﻿namespace AuthenticationPortal.Contracts
{
    public class SignInRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
