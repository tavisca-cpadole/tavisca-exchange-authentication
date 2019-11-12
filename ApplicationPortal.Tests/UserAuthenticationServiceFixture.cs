
using AuthenticationPortal.Contracts;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationPortal.Tests
{
    public class UserAuthenticationServiceFixture
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        public UserAuthenticationServiceFixture(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }
        [Fact]
        public async Task Sign_In_Service_Should_Not_Give_Token_To_Invalid_User()
        {
            SignInRequest signInRequest = new SignInRequest()
            {
                Password = "abrakadabra",
                RememberMe = false,
                Username = "chinmay"
            };
            Exception ex = await Assert.ThrowsAsync<CustomException>(() => _userAuthenticationService.SignInAsync(signInRequest));
            Assert.Equal("Invalid Username/Password", ex.Message);
        }
    }
}
