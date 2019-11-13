using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using AuthenticationPortal.Contracts;
using AuthenticationPortal.Core;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationPortal.AwsExtension
{
    public class AwsCognito : IUserAuthenticationAdapter
    {
        private readonly AwsCognitoCredentials _settings;
        private readonly IUserStoreFactory _userStoreFactory;
        private readonly IUserStore _userStore;
        public AwsCognito(IOptions<AwsCognitoCredentials> settings, IUserStore userStore)
        {
            _settings = settings.Value;
            _userStore = userStore;
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

                Contracts.AddUserRequest addUserRequest = new Contracts.AddUserRequest()
                {
                    Id = getUser.UserAttributes[1].Value,
                    FirstName = getUser.UserAttributes.Where(a => a.Name == "custom:Firstname").FirstOrDefault().Value,
                    LastName = getUser.UserAttributes.Where(a => a.Name == "custom:Lastname").FirstOrDefault().Value,
                    ContactNumber = getUser.UserAttributes.Where(a => a.Name == "phone_number").FirstOrDefault().Value,
                    Email = getUser.UserAttributes.Where(a => a.Name == "email").FirstOrDefault().Value,

                };
                if (UserDetails.GetAsync(addUserRequest.ToEntity(), _userStore).Result == null)
                {
                    var response = await UserDetails.SaveAsync(addUserRequest, _userStore);
                }
                _signInResponse.UserId = getUser.UserAttributes[1].Value;
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
