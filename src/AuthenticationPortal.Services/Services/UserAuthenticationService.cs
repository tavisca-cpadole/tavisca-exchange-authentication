using AuthenticationPortal.Contracts;
using System.Threading.Tasks;

namespace AuthenticationPortal.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserAuthenticationAdapter _userAuthenticationAdapter;
        public UserAuthenticationService(IUserAuthenticationAdapter userAuthenticationAdapter)
        {
            _userAuthenticationAdapter = userAuthenticationAdapter;
        }
        public Task<SignInResponse> SignInAsync(SignInRequest signInRequest)
        {
            return _userAuthenticationAdapter.SignInAsync(signInRequest);
        }
    }
}
