using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.Core
{
    public static class UserTranslator
    {
        public static UserEntity ToEntity(this Contracts.AddUserRequest request)
        {
            UserEntity user = new UserEntity()
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactNumber = request.ContactNumber,
                Email = request.Email
            };
            return user;
        }

        public static AddUserResponse ToModel(this UserResult user)
        {
            AddUserResponse response = new AddUserResponse()
            {
                UserId = user.UserId,
            };
            return response;
        }
    }
}
