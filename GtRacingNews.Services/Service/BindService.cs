using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace GtRacingNews.Services.Service
{
    public class BindService : IBindService
    {
        private readonly ISqlRepository sqlRepository;
        public BindService(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;

        public ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind)
        {
            var bindedNews = newsToBind.Select(x => new ShowAllNewsViewModel
            {
                Heading = x.Heading,
                Id = x.Id,
                ImgUrl = x.PictureUrl
            }).ToList();

            return bindedNews;
        }

        public ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind)
        {
            var teams = sqlRepository.GettAll<Team>();

            var bindedChampionships = championshipsToBind.Select(x => new ViewAllChampionshipsViewModel
            {
                ChampionshipId = x.Id,
                LogoUrl = x.LogoUrl,
                Name = x.Name,
                Teams = teams.Where(t => t.ChampionshipId == x.Id).Select(x => x.Name).ToList()
            }).ToList();

            return bindedChampionships;
        }

        public ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind)
        {
            var bindedDrivers = driversToBind.Select(x => new ViewAllDriversViewModel
            {
                Age = x.Age,
                Cup = x.Cup,
                DriverId = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
            }).ToList();

            return bindedDrivers;
        }

        public ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind)
        {
            var bindedRaces = racesToBind.Select(x => new ViewAllRacesViewModel
            {
                Name = x.Name,
                Date = x.Date,
                Id = x.Id,
                HasFinishied = false
            }).ToList();

            for (int i = 0; i < bindedRaces.Count(); i++)
            {
                DateTime date = DateTime.ParseExact(bindedRaces[i].Date, "dd/MM/yyyy", null);
                if (date < DateTime.Now) bindedRaces[i].HasFinishied = true;
            }

            bindedRaces = bindedRaces.OrderBy(x => DateTime.ParseExact(x.Date, "dd/MM/yyyy",null)).ToList();
            return bindedRaces;
        }

        public ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind)
        {
            var drivers = sqlRepository.GettAll<Driver>();

            var bindedTeams = teamsToBind.Select(x => new ViewAllTeamsViewModel
            {
                Name = x.Name,
                CarModel = x.CarModel,
                ChampionshipName = this.sqlRepository.FindById<Championship>(x.ChampionshipId).Name,
                Drivers = drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList(),
                Id = x.Id,
                LogoUrl = x.LogoUrl,
            }).ToList();

            return bindedTeams;
        }

        public ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind)
        {
            var bindedNews = newsToBind
              .Select(x => new ShowGuestNews
              {
                  Id = x.Id,
                  Heading = x.Heading,
                  Description = x.Description
              }).ToList();

            return bindedNews;
        }

        public MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile)
        {
            var model = new MyProfileViewModel();

            var teams = this.sqlRepository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = this.TeamBind(teams);

            var champs = this.sqlRepository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = this.ChampionshipBind(champs);

            var drivers = this.sqlRepository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = this.DriverBind(drivers);

            var races = this.sqlRepository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = this.RaceBind(races);

            var news = this.sqlRepository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindNews = this.NewsBind(news);

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
