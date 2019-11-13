namespace AuthenticationPortal.MongoDBStore
{
    public class MongoEntity
    {
        public string UserId { get; set; }

        public Name Name { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
}
