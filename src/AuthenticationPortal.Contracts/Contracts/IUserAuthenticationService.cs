using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface IUserAuthenticationService
    {
        Task<SignInResponse> SignInAsync(SignInRequest signInRequest);
    }
}
