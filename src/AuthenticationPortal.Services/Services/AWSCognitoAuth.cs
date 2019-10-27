using Amazon.CognitoIdentityProvider;
using AuthenticationPortal.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace AuthenticationPortal.Services
{
    public class AWSCognitoAuth : ControllerBase, ITokenAuthenticator
    {
        static readonly Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;

        public async Task<IActionResult> AuthenticateToken(Token token)
        {
            AmazonCognitoIdentityProviderClient aws =
                new AmazonCognitoIdentityProviderClient(
                    new Amazon.Runtime.AnonymousAWSCredentials(), region);

            try
            {
                var user = await aws.GetUserAsync(new Amazon.CognitoIdentityProvider.Model.GetUserRequest() { AccessToken = token.TokenString });
                return Ok();
            }
            catch
            {
                throw new CustomException(802);
            }
        }
    }
}
