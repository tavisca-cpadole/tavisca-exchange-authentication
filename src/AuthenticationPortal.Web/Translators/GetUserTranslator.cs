using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.Web
{
    public static class GetUserTranslator
    {
        public static GetUserDetailsRequest ToEntity(this string userId)
        {
            GetUserDetailsRequest getUserRequest = new GetUserDetailsRequest()
            {
                UserId = userId
            };
            return getUserRequest;
        }

        public static UserProfileResponse ToModel(this GetUserDetailsResponse user)
        {
            UserProfileResponse response = new UserProfileResponse()
            {
                userProfile = new UserProfile()
                {
                    Id = user.Id,
                    EmailId = user.Email,
                    ContactNumber = user.ContactNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ProfileImageUrl = "https://png.pngtree.com/png-vector/20190704/ourlarge/pngtree-vector-user-young-boy-avatar-icon-png-image_1538408.jpg"
                }
            };

            return response;
        }
    }
}
