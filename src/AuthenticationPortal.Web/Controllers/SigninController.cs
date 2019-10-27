using AuthenticationPortal.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationPortal.Web
{
    [Route("api/v1.0/ORP/[controller]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        private readonly IUserAuthentication _userAuthentication;
        private readonly IValidator<SignInRequest> _validator;
        public SigninController(IUserAuthentication userAuthentication, IValidator<SignInRequest> validator)
        {
            _userAuthentication = userAuthentication;
            _validator = validator;
        }

        // GET: api/Signin       
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Signin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Signin
        [HttpPost]
        public async Task<IActionResult> Post(SignInRequest signInRequest)
        {
            SignInRequest request = new SignInRequest();
            request.Password = signInRequest.Password;
            request.RememberMe = signInRequest.RememberMe;
            request.Username = signInRequest.Username;

            var result = _validator.Validate(request);

            if (result.IsValid)
            {
                var serviceResponse = await (_userAuthentication.SignIn(request));
                return Ok(serviceResponse.ToSignInWebResponse());
            }
            else
            {
                var msg = result.Errors.FirstOrDefault().ErrorMessage;
                return Ok(msg);
            }
        }

        // PUT: api/Signin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
