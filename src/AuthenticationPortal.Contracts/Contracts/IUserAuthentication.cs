using Authentication.Model;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public interface IUserAuthentication
    {
        Task<SignInResponse> SignIn(SignInRequest user);
    }
}
