using MongoDB.Bson;

namespace GtRacingNews.Repository.Contracts
{
    public interface IMongoRepository
    {
        public async Task AddAsync(string collectionName, BsonDocument item);

        public async Task AddRangeAsync(string collectionName, List<BsonDocument> ItemsToAdd);

        public BsonDocument FindById(string collectionName, string Id);

        public BsonDocument FindProfileByUserId(string collectionName, string Id);

        public BsonDocument FindByName(string collectionName, string name);

        public BsonDocument FindNewsByHeading(string collectionName, string heading);

        public async Task RemoveAsync(string collectionName, string Id);
    }
}
