using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface ITokenAuthenticationService
    {
        Task AuthenticateTokenAsync(TokenAuthenticationRequest token);
    }
}
