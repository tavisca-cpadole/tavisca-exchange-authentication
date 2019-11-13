using AuthenticationPortal.Contracts;
using MongoDB.Driver;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationPortal.MongoDBStore
{
    public class MongoUserStore : IUserStore<MongoUserStore>
    {
        private static MongoClient _dbClient = new MongoClient(new MongoClientSettings
        {
            Server = new MongoServerAddress(MongoDBConfiguration.Url, int.Parse(MongoDBConfiguration.Port)),
            SocketTimeout = new TimeSpan(0, 0, 0, 10),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 10)
        });
        private IMongoDatabase _db = _dbClient.GetDatabase(MongoDBConfiguration.Database);
        private string _collection = MongoDBConfiguration.ProductCollection;

        public async Task<UserResult> AddUserAsync(UserEntity query)
        {
            var mongoEntity = query.ToEntity();
            var userStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            try
            {
                var filter = Builders<MongoEntity>.Filter.Eq("userId", mongoEntity.UserId);
                await userStoreCollection.ReplaceOneAsync(filter, mongoEntity, new UpdateOptions { IsUpsert = true });
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, "Database_Down");
            }
            return mongoEntity.ToModel();
        }
    }
}
