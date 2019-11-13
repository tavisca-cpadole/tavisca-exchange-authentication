using AuthenticationPortal.Contracts;
using System.Threading.Tasks;

namespace AuthenticationPortal.Core
{
    public class UserDetails
    {
        public static async Task<AddUserResponse> SaveAsync(Contracts.AddUserRequest addUserRequest, IUserStore userStore)
        {
            var addUserQuery = addUserRequest.ToEntity();
            var addUserResponse = await userStore.AddUserAsync(addUserQuery);
            return addUserResponse.ToModel();
        }

        public static async Task<GetUser> GetAsync(GetUser user, IUserStore userStore)
        {
            var addUserQuery = user.ToEntity();
            var addUserResponse = await userStore.GetUserAsync(addUserQuery);
            return addUserResponse.ToModel();
        }
    }
}
