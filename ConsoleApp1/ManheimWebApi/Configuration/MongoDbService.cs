
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace ManheimWebApi.Configuration
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(MongoDBSettings settings,IMongoClient client)
        {
         
            _database = client.GetDatabase(settings.DbName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
