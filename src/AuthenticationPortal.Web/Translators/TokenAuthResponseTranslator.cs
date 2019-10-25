namespace AuthenticationPortal.Web
{
    public static class TokenAuthResponseTranslator
    {
        public static TokenAuthWebResponse ToTokenAuthWebResponse(this Contracts.TokenAuthenticationResponse serviceResponse)
        {
            TokenAuthWebResponse response = new TokenAuthWebResponse()
            {
                AuthenticationStatusCode = serviceResponse.AuthenticationStatusCode
            };
            return response;
        }
    }
}
