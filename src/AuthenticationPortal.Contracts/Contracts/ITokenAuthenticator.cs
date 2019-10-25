using Authentication.Model;
using AuthenticationPortal.Contracts;
using System.Threading.Tasks;

namespace Authentication.TokenAuthServices
{
    public interface ITokenAuthenticator
    {
        Task<TokenAuthenticationResponse> AuthenticateToken(Token token);
    }
}
