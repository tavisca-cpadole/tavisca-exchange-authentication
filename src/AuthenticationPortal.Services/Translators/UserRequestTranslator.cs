using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.Services
{
    public static class UserRequestTranslator
    {
        public static GetUser ToEntity(this GetUserDetailsRequest getUser)
        {
            GetUser user = new GetUser()
            {
                Id = getUser.UserId,
                ContactNumber = "",
                Email = "",
                FirstName = "",
                LastName = ""
            };
            return user;
        }

        public static GetUserDetailsResponse ToModel(this GetUser getUser)
        {
            GetUserDetailsResponse user = new GetUserDetailsResponse()
            {
                Id = getUser.Id,
                ContactNumber = getUser.ContactNumber,
                Email = getUser.Email,
                FirstName = getUser.FirstName,
                LastName = getUser.LastName
            };
            return user;
        }
    }
}
