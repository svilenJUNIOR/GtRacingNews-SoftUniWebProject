using GtRacingNews.Data.DataModels.MongoModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using MongoDB.Driver;

namespace GtRacingNews.Repository.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoDbContext mongoDbContext;
        public MongoRepository (MongoDbContext mongoDbContext)
            => this.mongoDbContext = mongoDbContext;


        public IMongoCollection<T> GettAll<T>(string name) =>
           mongoDbContext.GetCollection<T>(name);

        public Task AddAsync<T>(T newItem) where T : class
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync<T>(List<T> newItems) where T : class
        {
            throw new NotImplementedException();
        }

        public Championship FindChampionshipById(string? Id)
        {
            throw new NotImplementedException();
        }

        public Championship FindChampionshipByName(string name)
        {
            throw new NotImplementedException();
        }

        public Comment FindCommentById(string Id)
        {
            throw new NotImplementedException();
        }

        public Driver FindDriverById(string Id)
        {
            throw new NotImplementedException();
        }

        public Driver FindDriverByName(string name)
        {
            throw new NotImplementedException();
        }

        public News FindNewsById(string Id)
        {
            throw new NotImplementedException();
        }

        public News FindNewsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Profile FindProfileByUserId(string Id)
        {
            throw new NotImplementedException();
        }

        public Race FindRaceById(string Id)
        {
            throw new NotImplementedException();
        }

        public Race FindRaceByName(string name)
        {
            throw new NotImplementedException();
        }

        public Team FindTeamById(string Id)
        {
            throw new NotImplementedException();
        }

        public Team FindTeamByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync<T>(T Item) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
