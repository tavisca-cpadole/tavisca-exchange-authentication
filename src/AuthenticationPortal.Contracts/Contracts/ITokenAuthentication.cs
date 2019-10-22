using Authentication.Model;
using System.Threading.Tasks;

namespace Authentication.TokenAuthServices
{
    public interface ITokenAuthentication
    {
        Task<TokenAuthenticationResponse> AuthenticateToken(AccessToken token);
    }
}
