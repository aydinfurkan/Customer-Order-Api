using MongoDB.Driver;
using OrderApi.DatabaseSettings;
using OrderApi.Repository.Interfaces;

namespace OrderApi.Repository
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoContext _mongoContextImplementation;

        public MongoContext(OrderDatabaseSettings databaseSettings)
        {
            _mongoClient = new MongoClient(databaseSettings.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(databaseSettings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}