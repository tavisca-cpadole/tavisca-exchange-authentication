using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface ITokenAuthenticator
    {
        Task AuthenticateTokenAsync(Token token);
    }
}
