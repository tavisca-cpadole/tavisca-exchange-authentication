using Authentication.Model;
using System.Threading.Tasks;

namespace Authentication.TokenAuthServices
{
    public interface ITokenAuthenticator
    {
        Task<TokenAuthenticationResponse> AuthenticateToken(Token token);
    }
}
