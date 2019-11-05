using Amazon.CognitoIdentityProvider;
using AuthenticationPortal.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
namespace AuthenticationPortal.Services
{
    public class AWSCognitoAuth : ControllerBase, ITokenAuthenticator
    {
        static readonly Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;

        public async Task AuthenticateTokenAsync(Token token)
        {
            AmazonCognitoIdentityProviderClient aws =
                new AmazonCognitoIdentityProviderClient(
                    new Amazon.Runtime.AnonymousAWSCredentials(), region);

            try
            {
                var user = await aws.GetUserAsync(new Amazon.CognitoIdentityProvider.Model.GetUserRequest() { AccessToken = token.TokenKey });
                return;
            }
            catch
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Token Validation Error");
            }
        }
    }
}
