namespace AuthenticationPortal.Web
{
    public static class SignInResponseTranslator
    {
        public static SignInWebResponse ToSignInWebResponse(this Contracts.SignInResponse serviceResponse)
        {
            SignInWebResponse response = new SignInWebResponse()
            {
                RefreshToken = serviceResponse.RefreshToken,
                AccessToken = serviceResponse.AccessToken,
                UserId = serviceResponse.UserId

            };
            return response;
        }
    }
}
