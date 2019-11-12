using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.Web
{
    public static class SignInTranslator
    {
        public static SignInWebResponse ToModel(this SignInResponse serviceResponse)
        {
            SignInWebResponse response = new SignInWebResponse()
            {
                RefreshToken = serviceResponse.RefreshToken,
                AccessToken = serviceResponse.AccessToken,
                UserId = serviceResponse.UserId

            };
            return response;
        }

        public static SignInRequest ToEntity(this SignInRequest serviceRequest)
        {
            SignInRequest request = new SignInRequest()
            {
                Username = serviceRequest.Username,
                Password = serviceRequest.Password,
                RememberMe = serviceRequest.RememberMe

            };
            return request;
        }
    }
}
