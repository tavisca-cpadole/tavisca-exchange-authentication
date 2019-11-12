
using AuthenticationPortal.AwsExtension;
using AuthenticationPortal.Contracts;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationPortal.Tests
{
    public class AwsCognitoAuthServiceFixture
    {
        [Fact]
        public async Task Token_Authentication_Service_Should_Give_Error_Response_To_Invalid_Token()
        {
            TokenAuthenticationRequest token = new TokenAuthenticationRequest() { AccessToken = "asdasdasdasdasdasd" };
            AWSCognitoAuth awsCognitoAuth = new AWSCognitoAuth();

            Exception ex = await Assert.ThrowsAsync<CustomException>(() => awsCognitoAuth.AuthenticateTokenAsync(token));
            Assert.Equal("Invalid Access Token", ex.Message);
        }
    }
}
