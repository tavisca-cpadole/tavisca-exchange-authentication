using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface IUserDetailsService
    {
        Task<GetUserDetailsResponse> GetUserAsync(GetUserDetailsRequest request);
    }
}

