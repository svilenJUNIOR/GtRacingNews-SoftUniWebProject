using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class DeleteService : IDeleteService
    {
        private readonly IEngine engine;
        public DeleteService(IEngine engine) => this.engine = engine;
        public async Task Delete(string collection, string id)
        {
            if (collection == "Team") await engine.sqlRepository.RemoveAsync<Team>(engine.sqlRepository.FindTeamById(id));
            if (collection == "Championship") await engine.sqlRepository.RemoveAsync<Championship>(engine.sqlRepository.FindChampionshipById(id));
            if (collection == "Driver") await engine.sqlRepository.RemoveAsync<Driver>(engine.sqlRepository.FindDriverById(id));
            if (collection == "Comment") await engine.sqlRepository.RemoveAsync<Comment>(engine.sqlRepository.FindCommentById(id));
            if (collection == "Race") await engine.sqlRepository.RemoveAsync<Race>(engine.sqlRepository.FindRaceById(id));
            if (collection == "News") await engine.sqlRepository.RemoveAsync<News>(engine.sqlRepository.FindNewsById(id));
        }
        public async Task DeleteUserOrRole(string type, string id)
        {
            if (type == "User") await engine.sqlRepository.RemoveAsync<IdentityUser>(engine.sqlRepository.FindUserById(id));
         
            if (type == "Role") await engine.sqlRepository.RemoveAsync<IdentityRole>(engine.sqlRepository.FindRoleById(id));
        }
    }
}
