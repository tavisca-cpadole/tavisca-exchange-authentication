using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface ITokenAuthenticator
    {
        Task<IActionResult> AuthenticateToken(Token token);
    }
}
