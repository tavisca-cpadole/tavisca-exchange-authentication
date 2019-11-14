using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.Core
{
    public static class UserTranslator
    {
        public static UserEntity ToEntity(this Contracts.AddUserRequest request)
        {
            UserEntity user = new UserEntity()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactNumber = request.ContactNumber,
                Email = request.Email
            };
            return user;
        }

        public static AddUserResponse ToModel(this AddUserResult user)
        {
            AddUserResponse response = new AddUserResponse()
            {
                Id = user.Id,
            };
            return response;
        }

        public static GetUser ToModel(this GetUserResult user)
        {
            if (user == null)
                return null;
            GetUser response = new GetUser()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactNumber = user.ContactNumber,
                Email = user.Email
            };
            return response;
        }

        public static UserEntity ToEntity(this GetUser user)
        {
            if (user == null)
                return null;
            UserEntity response = new UserEntity()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactNumber = user.ContactNumber,
                Email = user.Email
            };
            return response;
        }
    }
}
