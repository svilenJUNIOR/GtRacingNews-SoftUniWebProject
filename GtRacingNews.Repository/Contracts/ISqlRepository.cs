using GtRacingNews.Data.DataModels.SqlModels;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Repository.Contracts
{
    public interface ISqlRepository
    {
        void SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> newItems) where T : class;
        Task RemoveAsync<T>(T Item) where T : class;
        IdentityUser FindUserByEmail(string email);
        IdentityUser FindUserById(string Id);
        IdentityRole FindRoleById(string Id);
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
