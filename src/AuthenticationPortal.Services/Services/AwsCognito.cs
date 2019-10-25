using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Authentication.Errors;
using AuthenticationPortal.Contracts;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class AwsCognito : IUserAuthentication
    {
        private readonly AwsCognitoCredentials _settings;
        public AwsCognito(IOptions<AwsCognitoCredentials> settings)
        {
            _settings = settings.Value;
        }

        public AwsCognito()
        {
        }

        static Amazon.RegionEndpoint region = Amazon.RegionEndpoint.APSouth1;
        private SignInResponse _signInResponse = new SignInResponse();

        public async Task<SignInResponse> SignIn(SignInRequest signInRequest)
        {
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
                GetUserRequest getUserRequest = new GetUserRequest();
                getUserRequest.AccessToken = authResponse.AuthenticationResult.AccessToken;
                GetUserResponse getUser = await providerClient.GetUserAsync(getUserRequest);

                //we will retrieve user id from user table from our DB
                _signInResponse.UserId = "12345";
                if (signInRequest.RememberMe)
                    _signInResponse.RefreshToken = authResponse.AuthenticationResult.RefreshToken;
                _signInResponse.AccessToken = authResponse.AuthenticationResult.AccessToken;

            }
            catch
            {
                throw new CustomException(801);
            }

            return _signInResponse;
        }
    }
}
