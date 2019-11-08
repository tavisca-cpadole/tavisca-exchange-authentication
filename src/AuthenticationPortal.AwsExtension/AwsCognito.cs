using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using AuthenticationPortal.Contracts;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationPortal.AwsExtension
{
    public class AwsCognito : IUserAuthenticationAdapter
    {
        private readonly AwsCognitoCredentials _settings;
        public AwsCognito(IOptions<AwsCognitoCredentials> settings)
        {
            _settings = settings.Value;
        }

        static Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;

        public async Task<SignInResponse> SignInAsync(SignInRequest signInRequest)
        {
            SignInResponse _signInResponse = new SignInResponse();
            var anonymousAwsCredentials = new Amazon.Runtime.AnonymousAWSCredentials();
            var amazonCognitoIdentityProviderClient = new AmazonCognitoIdentityProviderClient(anonymousAwsCredentials, region);
            AmazonCognitoIdentityProviderClient providerClient = amazonCognitoIdentityProviderClient;

            CognitoUserPool userPool = new CognitoUserPool(_settings.PoolId, _settings.ClientId, providerClient);
            CognitoUser cognitoUser = new CognitoUser(signInRequest.Username, _settings.ClientId, userPool, providerClient);

            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
            {
                Password = signInRequest.Password
            };
            try
            {
                AuthFlowResponse authResponse = await cognitoUser.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);
                var getUserRequest = new GetUserRequest()
                {
                    AccessToken = authResponse.AuthenticationResult.AccessToken
                };
                GetUserResponse getUser = await providerClient.GetUserAsync(getUserRequest);
                _signInResponse.UserId = getUser.UserAttributes[0].Value;
                if (signInRequest.RememberMe)
                    _signInResponse.RefreshToken = authResponse.AuthenticationResult.RefreshToken;
                _signInResponse.AccessToken = authResponse.AuthenticationResult.AccessToken;

            }
            catch
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Login_Error");
            }

            return _signInResponse;
        }
    }
}
