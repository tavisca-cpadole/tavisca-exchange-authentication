using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.Web
{
    public static class TokenAuthenticationTranslator
    {
        public static TokenAuthenticationRequest ToEntity(this TokenAuthenticationRequest serviceRequest)
        {
            TokenAuthenticationRequest request = new TokenAuthenticationRequest()
            {
                AccessToken = serviceRequest.AccessToken,
                UserId = serviceRequest.UserId
            };
            return request;
        }
    }
}
