using AuthenticationPortal.Contracts;
using AuthenticationPortal.Core;
using System.Threading.Tasks;

namespace AuthenticationPortal.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserStore _userStore;

        public UserDetailsService(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public async Task<GetUserDetailsResponse> GetUserAsync(GetUserDetailsRequest request)
        {
            var response = await UserDetails.GetAsync(request.ToEntity(), _userStore);
            return response.ToModel();
        }
    }
}
