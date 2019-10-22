using Authentication.Model;
using System;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class Vexiere : IUserAuthentication
    {
        public Task<SignInResponse> SignIn(SignInRequest signInRequest)
        {
            throw new NotImplementedException();
        }
    }
}
