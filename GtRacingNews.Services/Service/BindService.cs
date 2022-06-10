using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;

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
                ChampionshipName = this.sqlRepository.GettAll<Championship>()
                .Where(c => c.Id == x.ChampionshipId).Select(x => x.Name).FirstOrDefault(),
                HasFinishied = false
            }).ToList();

            for (int i = 0; i < bindedRaces.Count(); i++)
            {
                DateTime date = DateTime.Parse(bindedRaces[i].Date);
                if (date < DateTime.Now) bindedRaces[i].HasFinishied = true;
            }

            bindedRaces = bindedRaces.OrderBy(x => DateTime.Parse(x.Date)).ToList();
            return bindedRaces;
        }

        public ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind)
        {
            var drivers = sqlRepository.GettAll<Driver>();

            var bindedTeams = teamsToBind.Select(x => new ViewAllTeamsViewModel
            {
                Name = x.Name,
                CarModel = x.CarModel,
                ChampionshipName = this.sqlRepository.FindChampionshipById(x.ChampionshipId).Name,
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
    }
}
