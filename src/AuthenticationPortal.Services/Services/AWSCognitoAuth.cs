using Amazon.CognitoIdentityProvider;
using Authentication.Errors;
using Authentication.Model;
using AuthenticationPortal.Contracts;

using System.Threading.Tasks;
namespace Authentication.TokenAuthServices
{
    public class AWSCognitoAuth : ITokenAuthenticator
    {
        static readonly Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;
        TokenAuthenticationResponse tokenAuthenticationResponse = new TokenAuthenticationResponse();

        public async Task<TokenAuthenticationResponse> AuthenticateToken(Token token)
        {
            AmazonCognitoIdentityProviderClient aws =
                new AmazonCognitoIdentityProviderClient(
                    new Amazon.Runtime.AnonymousAWSCredentials(), region);

            try
            {

                var user = await aws.GetUserAsync(new Amazon.CognitoIdentityProvider.Model.GetUserRequest() { AccessToken = token.TokenString });
                tokenAuthenticationResponse.AuthenticationStatusCode = user.HttpStatusCode;
                return tokenAuthenticationResponse;
            }
            catch
            {
                throw new CustomException(802);
            }
        }
    }
}
