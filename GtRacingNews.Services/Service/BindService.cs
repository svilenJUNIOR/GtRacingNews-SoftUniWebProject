﻿//using GtRacingNews.Areas.Guest.ViewModels;
//using GtRacingNews.Data.DataModels;
//using GtRacingNews.Services.Contracts;
//using GtRacingNews.ViewModels.Championship;
//using GtRacingNews.ViewModels.Driver;
//using GtRacingNews.ViewModels.News;
//using GtRacingNews.ViewModels.Race;
//using GtRacingNews.ViewModels.Team;

//namespace GtRacingNews.Services.Service
//{
//    public class BindService : IBindService
//    {
//        private readonly IRepository repository;
//        public BindService(IRepository repository) => this.repository = repository;

//        public ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind)
//        {
//            var bindedNews = newsToBind.Select(x => new ShowAllNewsViewModel
//            {
//                Heading = x.Heading,
//                Id = x.Id,
//                ImgUrl = x.PictureUrl
//            }).ToList();

//            return bindedNews;
//        }

//        public ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind)
//        {
//            var teams = repository.GettAll<Team>();

//            var bindedChampionships = championshipsToBind.Select(x => new ViewAllChampionshipsViewModel
//            {
//                ChampionshipId = x.Id,
//                LogoUrl = x.LogoUrl,
//                Name = x.Name,
//                Teams = teams.Where(t => t.ChampionshipId == x.Id).Select(x => x.Name).ToList()
//            }).ToList();

//            return bindedChampionships;
//        }

//        public ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind)
//        {
//            var bindedDrivers = driversToBind.Select(x => new ViewAllDriversViewModel
//            {
//                Age = x.Age,
//                Cup = x.Cup,
//                DriverId = x.Id,
//                ImageUrl = x.ImageUrl,
//                Name = x.Name,
//            }).ToList();

//            return bindedDrivers;
//        }

//        public ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind)
//        {
//            var bindedRaces = racesToBind.Select(x => new ViewAllRacesViewModel
//            {
//                Name = x.Name,
//                Date = x.Date,
//                Id = x.Id,
//            }).ToList();

//            return bindedRaces;
//        }

//        public ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind)
//        {
//            var drivers = repository.GettAll<Driver>();

//            var bindedTeams = teamsToBind.Select(x => new ViewAllTeamsViewModel
//            {
//                Name = x.Name,
//                CarModel = x.CarModel,
//                ChampionshipName = this.repository.FindChampionshipById(x.ChampionshipId).Name,
//                Drivers = drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList(),
//                Id = x.Id,
//                LogoUrl = x.LogoUrl,
//            }).ToList();

//            return bindedTeams;
//        }

//        public ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind)
//        {
//            var bindedNews = newsToBind
//              .Select(x => new ShowGuestNews
//              {
//                  Id = x.Id,
//                  Heading = x.Heading,
//                  Description = x.Description
//              }).ToList();

//            return bindedNews;
//        }
//    }
//}
