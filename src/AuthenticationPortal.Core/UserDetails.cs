using AuthenticationPortal.Contracts;
using AuthenticationPortal.MongoDBStore;
using System.Threading.Tasks;

namespace AuthenticationPortal.Core
{
    public class UserDetails
    {
        public static async Task<AddUserResponse> SaveAsync(Contracts.AddUserRequest addUserRequest, IUserStore<MongoUserStore> userStore)
        {
            var addUserQuery = addUserRequest.ToEntity();
            var addUserResponse = await userStore.AddUserAsync(addUserQuery);
            return addUserResponse.ToModel();
        }
    }
}
