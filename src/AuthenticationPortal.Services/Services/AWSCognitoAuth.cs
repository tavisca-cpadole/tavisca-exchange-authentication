using Amazon.CognitoIdentityProvider;
using AuthenticationPortal.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
namespace AuthenticationPortal.Services
{
    public class AWSCognitoAuth : ControllerBase, ITokenAuthenticatorAdapter
    {
        static readonly Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;

        public async Task AuthenticateTokenAsync(TokenAuthenticationRequest token)
        {
            var anonymousAwsCredentials = new Amazon.Runtime.AnonymousAWSCredentials();
            var amazonCognitoIdentityProviderClient = new AmazonCognitoIdentityProviderClient(anonymousAwsCredentials, region);
            AmazonCognitoIdentityProviderClient providerClient = amazonCognitoIdentityProviderClient;

            try
            {
                var user = await providerClient.GetUserAsync(new Amazon.CognitoIdentityProvider.Model.GetUserRequest() { AccessToken = token.AccessToken });
                return;
            }
            catch
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Token Validation Error");
            }
        }
    }
}
