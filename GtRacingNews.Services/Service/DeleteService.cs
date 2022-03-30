using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class DeleteService : IDeleteService
    {
        private readonly IRepository repository;

        public DeleteService(IRepository repository) => this.repository = repository;

        public async Task Delete(string collection, int id)
        {
            if (collection == "Team") await repository.RemoveAsync<Team>(repository.FindTeamById(id));
            if (collection == "Championship") await repository.RemoveAsync<Championship>(repository.FindChampionshipById(id));
            if (collection == "Driver") await repository.RemoveAsync<Driver>(repository.FindDriverById(id));
            if (collection == "Comment") await repository.RemoveAsync<Comment>(repository.FindCommentById(id));
            if (collection == "Race") await repository.RemoveAsync<Race>(repository.FindRaceById(id));
            if (collection == "News") await repository.RemoveAsync<News>(repository.FindNewsById(id));
        }
        public async Task Delete(string type, string id)
        {
            if (type == "User") await repository.RemoveAsync<IdentityUser<string>>(repository.FindUserById(id));
         
            if (type == "Role") await repository.RemoveAsync<IdentityRole<string>>(repository.FindRoleById(id));
        }
    }
}
