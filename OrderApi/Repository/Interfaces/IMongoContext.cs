using MongoDB.Driver;

namespace OrderApi.Repository.Interfaces
{
    public interface IMongoContext
    {
        public IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}