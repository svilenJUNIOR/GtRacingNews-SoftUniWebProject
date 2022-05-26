using GtRacingNews.Data.DataModels;

namespace GtRacingNews.Repository.Contracts
{
    public interface IMongoRepository
    {
        void Seeder();
        void SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> newItems) where T : class;
        Task RemoveAsync<T>(T Item) where T : class;
        List<T> GettAll<T>() where T : class;

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
