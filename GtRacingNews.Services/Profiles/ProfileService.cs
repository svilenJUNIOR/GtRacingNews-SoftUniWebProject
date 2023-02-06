using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Championships;
using GtRacingNews.Services.Drivers;
using GtRacingNews.Services.Newss;
using GtRacingNews.Services.Races;
using GtRacingNews.Services.Teams;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Profiles
{
    public class ProfileService : IProfileService
    {
        private ISqlRepository sqlRepository;
        private IChampionshipService championshipService;
        private IDriverService driverService;
        private INewsService newsService;
        private IRaceService raceService;
        private ITeamService teamService;

        public ProfileService(ISqlRepository sqlRepository, IChampionshipService championshipService, IDriverService driverService, INewsService newsService, IRaceService raceService, ITeamService teamService)
        {
            this.sqlRepository = sqlRepository;
            this.championshipService = championshipService;
            this.driverService = driverService;
            this.newsService = newsService;
            this.raceService = raceService;
            this.teamService = teamService;
        }

        public async Task AddNewProfile(string address, int age, string userId, string profileType, string profilePicture)
        {
            var profile = new Profile(age, profileType, userId, address, profilePicture);
            await sqlRepository.AddAsync<Profile>((Profile)profile);
        }
        public void EditProfileInfo(string Id, CreatePremiumFormModel data)
        {
            var profile = this.sqlRepository.FindByUserId(Id);

            profile.Address = data.Address;
            profile.Age = data.Age;
            profile.ProfilePicture = data.ProfilePicture;

            this.sqlRepository.SaveChangesAsync();
        }
        public MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile)
        {
            var model = new MyProfileViewModel();

            var teams = this.sqlRepository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = this.teamService.TeamBind(teams);

            var champs = this.sqlRepository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = this.championshipService.ChampionshipBind(champs);

            var drivers = this.sqlRepository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = this.driverService.DriverBind(drivers);

            var races = this.sqlRepository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = this.raceService.RaceBind(races);

            var news = this.sqlRepository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindNews = this.newsService.NewsBind(news);

            model.Teams = bindTeams.ToList();
            model.Championships = bindChamps.ToList();
            model.Drivers = bindDrivers.ToList();
            model.News = bindNews.ToList();
            model.Races = bindRaces.ToList();
            model.Age = userProfile.Age;
            model.Email = currentUser.Email;
            model.Address = userProfile.Address;
            model.ProfilePicture = userProfile.ProfilePicture;

            return model;
        }
    }
}
