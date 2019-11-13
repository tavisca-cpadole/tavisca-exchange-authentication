using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface IUserStore<T> where T : class
    {
        Task<UserResult> AddUserAsync(UserEntity request);
    }
}
