using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.AwsExtension
{
    public static class UserTranslator
    {
        public static GetUser ToEntity(this AddUserRequest request)
        {
            GetUser user = new GetUser()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactNumber = request.ContactNumber,
                Email = request.Email
            };
            return user;
        }
    }
}
