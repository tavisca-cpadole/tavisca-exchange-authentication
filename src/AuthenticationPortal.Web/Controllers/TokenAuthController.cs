using AuthenticationPortal.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationPortal.Web
{
    [Route("api/v1.0/ORP/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly ITokenAuthenticator tokenAuthentication;
        public TokenAuthController(ITokenAuthenticator tokenAuthentication)
        {
            this.tokenAuthentication = tokenAuthentication;
        }

        // GET: api/<controller>
        [HttpGet("validateToken")]
        public async Task<IActionResult> TryTokenValidationAsync()
        {
            StringValues x;
            if (Request.Headers.TryGetValue("AuthKey", out x))
            {
                Token token = new Token() { TokenKey = x.First() };
                await tokenAuthentication.AuthenticateTokenAsync(token);
                return Ok();
            }
            else
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Token Request Error");
            }

        }
    }
}
