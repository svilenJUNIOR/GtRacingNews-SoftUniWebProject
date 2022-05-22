using GtRacingNews.Data.DataModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class DeleteService : IDeleteService
    {
        private readonly ISqlRepoisitory sqlRepository;

        public DeleteService(ISqlRepoisitory sqlRepository) => this.sqlRepository = sqlRepository;

        public async Task Delete(string collection, string id)
        {
            if (collection == "Team") await sqlRepository.RemoveAsync<Team>(sqlRepository.FindTeamById(id));
            if (collection == "Championship") await sqlRepository.RemoveAsync<Championship>(sqlRepository.FindChampionshipById(id));
            if (collection == "Driver") await sqlRepository.RemoveAsync<Driver>(sqlRepository.FindDriverById(id));
            if (collection == "Comment") await sqlRepository.RemoveAsync<Comment>(sqlRepository.FindCommentById(id));
            if (collection == "Race") await sqlRepository.RemoveAsync<Race>(sqlRepository.FindRaceById(id));
            if (collection == "News") await sqlRepository.RemoveAsync<News>(sqlRepository.FindNewsById(id));
        }
        public async Task DeleteUserOrRole(string type, string id)
        {
            if (type == "User") await sqlRepository.RemoveAsync<IdentityUser>(sqlRepository.FindUserById(id));
         
            if (type == "Role") await sqlRepository.RemoveAsync<IdentityRole>(sqlRepository.FindRoleById(id));
        }
    }
}
