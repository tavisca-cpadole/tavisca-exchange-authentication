
using AuthenticationPortal.Contracts;
using AuthenticationPortal.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationPortal.Tests
{
    public class AwsCogintoServiceFixture
    {
        [Fact]
        public async Task Sign_In_Service_Should_Not_Give_Token_To_Invalid_User()
        {
            SignInRequest signInRequest = new SignInRequest()
            {
                Password = "abrakadabra",
                RememberMe = false,
                Username = "chinmay"
            };

            AwsCognito awsCognito = new AwsCognito();
            Exception ex = await Assert.ThrowsAsync<CustomException>(() => awsCognito.SignIn(signInRequest));
            Assert.Equal("Invalid Username/Password", ex.Message);
        }
    }
}
