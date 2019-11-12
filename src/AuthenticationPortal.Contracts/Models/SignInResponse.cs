namespace AuthenticationPortal.Contracts
{
    public class SignInResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string UserId { get; set; }

    }
}
