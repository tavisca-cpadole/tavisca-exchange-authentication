using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.MongoDBStore
{
    public static class UserQueryTranslator
    {
        public static MongoEntity ToEntity(this UserEntity query)
        {
            MongoEntity mongoEntity = new MongoEntity()
            {
                UserId = query.UserId,
                Name = new Name() { FirstName = query.FirstName, LastName = query.LastName },
                ContactDetails = new ContactDetails() { ContactNumber = query.ContactNumber, Email = query.Email }
            };
            return mongoEntity;
        }

        public static UserResult ToModel(this MongoEntity query)
        {
            return new UserResult() { UserId = query.UserId };
        }
    }
}
