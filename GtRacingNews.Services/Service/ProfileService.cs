using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IBindService bindService;
        private readonly ISqlRepository sqlRepository;
        public ProfileService(IBindService bindService, ISqlRepository sqlRepository)
        {
            this.bindService = bindService;
            this.sqlRepository = sqlRepository;
        }
        public MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile)
        {
            var model = new MyProfileViewModel();

            var teams = this.sqlRepository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = bindService.TeamBind(teams);

            var champs = this.sqlRepository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = bindService.ChampionshipBind(champs);

            var drivers = this.sqlRepository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = bindService.DriverBind(drivers);

            var races = this.sqlRepository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = bindService.RaceBind(races);

            var news = this.sqlRepository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindNews = bindService.NewsBind(news);

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
