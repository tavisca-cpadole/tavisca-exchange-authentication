using System.Threading.Tasks;

namespace AuthenticationPortal.Contracts
{
    public interface IUserAuthentication
    {
        Task<SignInResponse> SignIn(SignInRequest user);
    }
}
