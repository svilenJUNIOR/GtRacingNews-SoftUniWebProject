using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Service
{
    public class EditService : IEditService
    {
        private ISqlRepository sqlRepository;

        public EditService(ISqlRepository sqlRepository) 
            => this.sqlRepository = sqlRepository;

        public void EditChampionship(string Id, AddNewChampionshipFormModel data)
        {
            var champ = this.sqlRepository.FindById<Championship>(Id);

            champ.LogoUrl = data.LogoUrl;
            champ.Name = data.Name;

            this.sqlRepository.SaveChangesAsync();
        }
        public void EditDriver(string Id, AddNewDriverFormModel data)
        {
            var driver = this.sqlRepository.FindById<Driver>(Id);

            driver.ImageUrl = data.ImageUrl;
            driver.Name = data.Name;
            driver.Age = data.Age;
            driver.Cup = data.Cup;

            this.sqlRepository.SaveChangesAsync();
        }
        public void EditNews(string Id, AddNewFormModel data)
        {
            var news = this.sqlRepository.FindById<News>(Id);

            news.PictureUrl = data.PictureUrl;
            news.Description = data.Description;
            news.Heading = data.Heading;

            this.sqlRepository.SaveChangesAsync();
        }
        public void EditProfileInfo(string Id, CreatePremiumFormModel data)
        {
            var profile = this.sqlRepository.FindByUserId(Id);

            profile.Address = data.Address;
            profile.Age = data.Age;
            profile.ProfilePicture = data.ProfilePicture;

            this.sqlRepository.SaveChangesAsync();
        }
        public void EditRace(string Id, AddNewRaceFormModel data)
        {
            var race = this.sqlRepository.FindById<Race>(Id);

            race.Date = data.Date;
            race.Name = data.Name;

            this.sqlRepository.SaveChangesAsync();
        }
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
