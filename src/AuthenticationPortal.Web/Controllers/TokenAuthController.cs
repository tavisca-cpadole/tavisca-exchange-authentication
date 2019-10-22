using Authentication.Model;
using Authentication.TokenAuthServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;


namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly ITokenAuthentication tokenAuthentication;
        public TokenAuthController(ITokenAuthentication tokenAuthentication)
        {
            this.tokenAuthentication = tokenAuthentication;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {

            StringValues x = default;

            if (Request.Headers.TryGetValue("AuthKey", out x))
            {
                AccessToken token = new AccessToken() { TokenString = x.First<string>() };
                return Ok(tokenAuthentication.AuthenticateToken(token).Result);
            }
            else
            {
                throw new MissingHeaderException("Header is missing the AuthKey Field");
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
