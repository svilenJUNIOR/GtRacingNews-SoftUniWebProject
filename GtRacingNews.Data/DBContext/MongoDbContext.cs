using GtRacingNews.Data.DataModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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

        public async void Seed()
        {
            var collection = db.GetCollection<BsonDocument>("Drivers");

            var drivers = new BsonDocument
            {
                { "Name", "Rolf Ineichen" },
                { "Age", 43 },
                { "Cup", "Pro" },
                { "ImageUrl", "https://www.intercontinentalgtchallenge.com/timthumb.php?w=640&src=%2Fimages%2Fdrivers%2FRolf_Ineichen2018.jpg"},
                { "TeamId", "a158bc3a-1de8-421e-8e83-925089919d78" },
                { "Name", "Rolf Ineichen" },
                { "Age", 43 },
                { "Cup", "Pro" },
                { "ImageUrl", "https://www.intercontinentalgtchallenge.com/timthumb.php?w=640&src=%2Fimages%2Fdrivers%2FRolf_Ineichen2018.jpg"},
                { "TeamId", "a158bc3a-1de8-421e-8e83-925089919d78" },
            };
            await collection.InsertOneAsync(drivers);

        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return db.GetCollection<T>(name);
        }
    }
}
