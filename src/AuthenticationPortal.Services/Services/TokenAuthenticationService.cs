using AuthenticationPortal.Contracts;
using System.Threading.Tasks;

namespace AuthenticationPortal.Services
{
    public class TokenAuthenticationService : ITokenAuthenticationService
    {
        private readonly ITokenAuthenticatorAdapter _tokenAuthenticatorAdapter;
        public TokenAuthenticationService(ITokenAuthenticatorAdapter tokenAuthenticatorAdapter)
        {
            _tokenAuthenticatorAdapter = tokenAuthenticatorAdapter;
        }
        public Task AuthenticateTokenAsync(TokenAuthenticationRequest tokenAuthenticationRequest)
        {
            return _tokenAuthenticatorAdapter.AuthenticateTokenAsync(tokenAuthenticationRequest);
        }
    }
}
