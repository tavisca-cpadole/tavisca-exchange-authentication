using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface IUserStore
    {
        Task<AddUserResult> AddUserAsync(UserEntity request);
        Task<GetUserResult> GetUserAsync(UserEntity request);
    }
}
