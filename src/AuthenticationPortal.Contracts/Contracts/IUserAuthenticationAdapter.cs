using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface IUserAuthenticationAdapter
    {
        Task<SignInResponse> SignInAsync(SignInRequest user);
    }
}
