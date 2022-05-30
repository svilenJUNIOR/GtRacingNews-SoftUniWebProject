using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Delete;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class DeleteService : IDeleteService
    {
        private readonly ISqlRepository sqlRepository;
        public DeleteService(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;
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
        public DeleteFormModel GetItemsForDeletion()
        {
            var deleteModel = new DeleteFormModel();

            var Teams = this.sqlRepository.GettAll<Team>();
            var Drivers = this.sqlRepository.GettAll<Driver>();
            var Championships = this.sqlRepository.GettAll<Championship>();
            var News = this.sqlRepository.GettAll<News>();
            var Races = this.sqlRepository.GettAll<Race>();
            var Users = this.sqlRepository.GettAll<IdentityUser>();
            var Roles = this.sqlRepository.GettAll<IdentityRole>();

            foreach (var team in Teams)
                deleteModel.Teams.Add(team.Name, team.Id);

            foreach (var driver in Drivers)
                deleteModel.Drivers.Add(driver.Name, driver.Id);

            foreach (var championship in Championships)
                deleteModel.Championships.Add(championship.Name, championship.Id);

            foreach (var news in News)
                deleteModel.News.Add(news.Heading, news.Id);

            foreach (var race in Races)
                deleteModel.Races.Add(race.Name, race.Id);

            foreach (var user in Users)
                deleteModel.Users.Add(user.UserName, user.Id);

            foreach (var role in Roles)
                deleteModel.Roles.Add(role.Name, role.Id);

            return deleteModel;
        }
    }
}
