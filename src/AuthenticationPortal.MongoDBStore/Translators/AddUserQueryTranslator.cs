using AuthenticationPortal.Contracts;

namespace AuthenticationPortal.MongoDBStore
{
    public static class AddUserQueryTranslator
    {
        public static MongoEntity ToEntity(this UserEntity query)
        {
            MongoEntity mongoEntity = new MongoEntity()
            {
                Id = query.Id,
                Name = new Name() { FirstName = query.FirstName, LastName = query.LastName },
                ContactDetails = new ContactDetails() { ContactNumber = query.ContactNumber, Email = query.Email }
            };
            return mongoEntity;
        }

        public static AddUserResult ToModel(this MongoEntity query)
        {
            return new AddUserResult() { Id = query.Id };
        }
    }
}
