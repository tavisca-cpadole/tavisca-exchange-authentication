using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface ITokenAuthenticatorAdapter
    {
        Task AuthenticateTokenAsync(TokenAuthenticationRequest token);
    }
}
