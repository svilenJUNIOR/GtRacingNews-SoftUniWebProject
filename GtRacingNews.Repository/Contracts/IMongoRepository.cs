using GtRacingNews.Data.DataModels.MongoModels;
using MongoDB.Driver;

namespace GtRacingNews.Repository.Contracts
{
    public interface IMongoRepository
    {
        void SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> newItems) where T : class;
        Task RemoveAsync<T>(T Item) where T : class;
        IMongoCollection<T> GettAll<T>(string name);

        Team FindTeamById(string Id);
        Profile FindProfileByUserId(string Id);
        Championship FindChampionshipById(string? Id);
        Driver FindDriverById(string Id);
        Comment FindCommentById(string Id);
        Race FindRaceById(string Id);
        News FindNewsById(string Id);

        Team FindTeamByName(string name);
        Championship FindChampionshipByName(string name);
        Driver FindDriverByName(string name);
        Race FindRaceByName(string name);
        News FindNewsByName(string name);
    }
}
