using Authentication.Errors;
using Authentication.Model;
using Authentication.TokenAuthServices;
using AuthenticationPortal.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;


namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly ITokenAuthenticator tokenAuthentication;
        public TokenAuthController(ITokenAuthenticator tokenAuthentication)
        {
            this.tokenAuthentication = tokenAuthentication;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            StringValues x;
            if (Request.Headers.TryGetValue("AuthKey", out x))
            {
                Token token = new Token() { TokenString = x.First() };
                var serviceResponse = tokenAuthentication.AuthenticateToken(token).Result;
                return Ok(serviceResponse.ToTokenAuthWebResponse());
            }
            else
            {
                throw new CustomException(803);
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(string token)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
