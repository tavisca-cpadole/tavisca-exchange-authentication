using Amazon.CognitoIdentityProvider;
using Authentication.Model;
using System.Threading.Tasks;
namespace Authentication.TokenAuthServices
{
    public class AWSCognitoAuth : ITokenAuthentication
    {
        static readonly Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;
        TokenAuthenticationResponse tokenAuthenticationResponse = new TokenAuthenticationResponse();
        public async Task<TokenAuthenticationResponse> AuthenticateToken(AccessToken token)
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
                throw new InvalidTokenException("Invalid Access Token");
            }
        }

    }
}
