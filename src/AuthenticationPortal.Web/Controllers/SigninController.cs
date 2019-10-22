using Authentication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/v1.0/ORP/[controller]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        private readonly IUserAuthentication userAuthentication;
        public SigninController(IUserAuthentication userAuthentication)
        {
            this.userAuthentication = userAuthentication;
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
            return Ok(userAuthentication.SignIn(signInRequest).Result);
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
