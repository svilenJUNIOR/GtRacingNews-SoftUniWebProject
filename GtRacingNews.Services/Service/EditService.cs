using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Service
{
    public class EditService : IEditService
    {
        private ISqlRepository sqlRepository;

        public EditService(ISqlRepository sqlRepository) 
            => this.sqlRepository = sqlRepository;

        public void EditTeam(string Id, AddTeamFormModel data)
        {
            var team = this.sqlRepository.FindById<Team>(Id);

            team.Name = data.Name;
            team.LogoUrl = data.LogoUrl;
            team.CarModel = data.CarModel;
            team.ChampionshipId = this.sqlRepository.GettAll<Championship>().
                FirstOrDefault(x => x.Name == data.ChampionshipName).Id;

            this.sqlRepository.SaveChangesAsync();
        }
    }
}
