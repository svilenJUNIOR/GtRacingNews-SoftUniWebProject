using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.Delete;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Others
{
    public class DeleteService : IDeleteService
    {
        private readonly ISqlRepository sqlRepository;
        public DeleteService(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;
        public async Task Delete<T>(string id) where T : class
            => await sqlRepository.RemoveAsync(sqlRepository.FindById<T>(id));

        public async Task DeleteUser(string id)
          => await sqlRepository.RemoveAsync(sqlRepository.FindUserById(id));

        public async Task DeleteRole(string id)
          => await sqlRepository.RemoveAsync(sqlRepository.FindRoleById(id));

        public DeleteFormModel GetItemsForDeletion()
        {
            var deleteModel = new DeleteFormModel();

            var Teams = sqlRepository.GettAll<Team>();
            var Drivers = sqlRepository.GettAll<Driver>();
            var Championships = sqlRepository.GettAll<Championship>();
            var News = sqlRepository.GettAll<News>();
            var Races = sqlRepository.GettAll<Race>();
            var Users = sqlRepository.GettAll<IdentityUser>();
            var Roles = sqlRepository.GettAll<IdentityRole>();

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
