using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.MongoDBStore
{
    public static class GetUserQueryTranslator
    {
        public static GetUserResult ToGetUserModel(this MongoEntity mongoEntity)
        {
            if (mongoEntity == null)
                return null;
            GetUserResult getUserResult = new GetUserResult()
            {
                Id = mongoEntity.Id,
                ContactNumber = mongoEntity.ContactDetails.ContactNumber,
                Email = mongoEntity.ContactDetails.Email,
                FirstName = mongoEntity.Name.FirstName,
                LastName = mongoEntity.Name.LastName
            };
            return getUserResult;
        }
    }
}
