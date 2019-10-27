using Authentication.Errors;
using Authentication.Services;
using AuthenticationPortal.Contracts;

namespace ApplicationPortal.Tests
{
    class SignInControllerFixture
    {
        public void Sign_In_Controller_Should_Not_Give_Token_To_Invalid_User()
        {
            SignInRequest signInRequest = new SignInRequest()
            {
                Password = "abrakadabra",
                RememberMe = false,
                Username = "chinmay"
            };

            CustomErrorResponse customErrorResponse = new CustomErrorResponse()
            {
                Code = 801,
                Message = "Invalid Username/Password"
            };
            AwsCognito awsCognito = new AwsCognito();
            // Assert.Equal(customErrorResponse, awsCognito.SignIn(signInRequest));
        }
    }
}
