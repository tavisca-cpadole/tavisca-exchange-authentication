using AuthenticationPortal.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationPortal.Web.Controllers
{
    [Route("api/v1.0/OnlineRetailPortal")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        //validator implementation is pending, next sprint
        private readonly IUserDetailsService _userDetailsService;
        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            this._userDetailsService = userDetailsService;
        }

        // GET: api/UserDetails/5
        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            // TBA- validations
            var serviceResponse = await (_userDetailsService.GetUserAsync(userId.ToEntity()));
            return Ok(serviceResponse.ToModel());
        }
    }
}
