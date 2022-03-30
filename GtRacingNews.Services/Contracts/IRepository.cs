using GtRacingNews.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services
{
    public interface IRepository
    {
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> newItems) where T : class;
        Task RemoveAsync<T>(T Item) where T : class;
        IdentityUser FindUserByEmail(string email);
        IdentityUser FindUserById(string Id);
        IdentityRole FindRoleById(string Id);
        ICollection<T> GettAll<T>() where T : class;

        Team FindTeamById(int Id);
        Championship FindChampionshipById(int Id);
        Driver FindDriverById(int Id);
        Comment FindCommentById(int Id);
        Race FindRaceById(int Id);
        News FindNewsById(int Id);

        Team FindTeamByName(string name);
        Championship FindChampionshipByName(string name);
        Driver FindDriverByName(string name);
        Race FindRaceByName(string name);
        News FindNewsByName(string name);
    }
}
