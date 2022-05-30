using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtRacingNews.Data.DBContext
{
    public class MongoDbContext
    {
        private IMongoDatabase db { get; set; }
        private MongoClient mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public MongoDbContext(IOptions<MongoSetUp> configuration)
        {
            mongoClient = new MongoClient(configuration.Value.Connection);
            db = mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public MongoDbContext()
        {

        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return db.GetCollection<T>(name);
        }

        public void create()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("GTNews");
            db.CreateCollection("Teams");
            db.CreateCollection("Championships");
            db.CreateCollection("Comments");
            db.CreateCollection("Drivers");
            db.CreateCollection("News");
            db.CreateCollection("Profiles");
            db.CreateCollection("Races");
        }

        public void delete()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.DropDatabase("GTNews");
        }
    }
}
