namespace AuthenticationPortal.Contracts
{
    public class TokenAuthenticationRequest
    {
        public string AccessToken { get; set; }
        public string UserId { get; set; }
    }
}
