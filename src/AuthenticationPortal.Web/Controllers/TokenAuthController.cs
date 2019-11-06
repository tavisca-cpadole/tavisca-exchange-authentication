using AuthenticationPortal.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationPortal.Web
{
    [Route("api/v1.0/ORP")]
    public class TokenAuthController : Controller
    {
        private readonly ITokenAuthenticationService _tokenAuthenticationService;
        private readonly IValidator<TokenAuthenticationRequest> _validator;
        public TokenAuthController(ITokenAuthenticationService tokenAuthenticationService, IValidator<TokenAuthenticationRequest> validator)
        {
            _tokenAuthenticationService = tokenAuthenticationService;
            _validator = validator;
        }

        // POST: api/<controller>
        [HttpPost("validateToken")]
        public async Task<IActionResult> TryTokenValidationAsync([FromBody] TokenAuthenticationRequest tokenAuthenticationRequest)
        {
            _validator.EnsureValid(tokenAuthenticationRequest);
            var request = tokenAuthenticationRequest.ToEntity();
            await _tokenAuthenticationService.AuthenticateTokenAsync(request);
            return Ok(tokenAuthenticationRequest);
        }
    }
}

