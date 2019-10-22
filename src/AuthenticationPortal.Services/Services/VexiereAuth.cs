using Authentication.Model;
using System.Threading.Tasks;

namespace Authentication.TokenAuthServices
{
    public class VexiereAuth : ITokenAuthentication
    {
        public Task<TokenAuthenticationResponse> AuthenticateToken(AccessToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}
