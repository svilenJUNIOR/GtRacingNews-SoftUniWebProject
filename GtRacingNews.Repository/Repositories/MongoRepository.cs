using GtRacingNews.Data.DataModels.MongoModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GtRacingNews.Repository.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoDbContext mongoDbContext;
        public MongoRepository (MongoDbContext mongoDbContext)
            => this.mongoDbContext = mongoDbContext;


        public async Task AddAsync(string collectionName, BsonDocument item)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            await collection.InsertOneAsync(item);
        }

        public async Task AddRangeAsync(string collectionName, List<BsonDocument> ItemsToAdd)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            await collection.InsertManyAsync(ItemsToAdd);
        }

        public BsonDocument FindById(string collectionName, string Id)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", Id);
            var item = collection.Find(filter).FirstOrDefault();

            return item;
        }

        public BsonDocument FindProfileByUserId(string collectionName, string Id)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("UserId", Id);
            var item = collection.Find(filter).FirstOrDefault();

            return item;
        }

        public BsonDocument FindByName(string collectionName, string name)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            var item = collection.Find(filter).FirstOrDefault();

            return item;
        }

        public BsonDocument FindNewsByHeading(string collectionName, string heading)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("Heading", heading);
            var item = collection.Find(filter).FirstOrDefault();

            return item;
        }

        public async Task RemoveAsync(string collectionName, string Id)
        {
            var collection = mongoDbContext.GetCollection<BsonDocument>(collectionName);
            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", Id);
            await collection.DeleteOneAsync(deleteFilter);
        }
    }
}
