using AuthenticationPortal.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace AuthenticationPortal.Web
{
    [Route("api/v1.0/ORP")]
    [ApiController]
    public class SigninController : ControllerBase
    {

        private readonly IUserAuthenticationService userAuthenticationService;
        private readonly IValidator<SignInRequest> _validator;
        public SigninController(IUserAuthenticationService userAuhenticationService, IValidator<SignInRequest> validator)
        {
            this.userAuthenticationService = userAuhenticationService;
            _validator = validator;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(SignInRequest signInRequest)
        {
            _validator.EnsureValid(signInRequest);
            var request = signInRequest.ToEntity();
            var serviceResponse = await (userAuthenticationService.SignInAsync(request));
            return Ok(serviceResponse);

        }
    }
}
