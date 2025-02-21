using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.ORM.MongoDB
{
    public class MongoDBService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("MongoDBConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClientSettings = new MongoClientSettings
            {
                Server = mongoUrl.Server,
                Credential = MongoCredential.CreateCredential(mongoUrl.DatabaseName, _configuration["MongoDB:Username"], _configuration["MongoDB:Password"])
            };
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        public IMongoDatabase Database => _database;
    }
}
