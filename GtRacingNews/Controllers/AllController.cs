using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Championships;
using GtRacingNews.Services.Drivers;
using GtRacingNews.Services.Newss;
using GtRacingNews.Services.Races;
using GtRacingNews.Services.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    [Authorize]
    public class AllController : Controller
    {
        private IChampionshipService championshipService;
        private IDriverService driverService;
        private INewsService newsService;
        private IRaceService raceService;
        private ITeamService teamService;
        public AllController(IChampionshipService championshipService, IDriverService driverService, INewsService newsService, IRaceService raceService, ITeamService teamService)
        {
            this.championshipService = championshipService;
            this.driverService = driverService;
            this.newsService = newsService;
            this.raceService = raceService;
            this.teamService = teamService;
        }

        public async Task<IActionResult> AllChampionships() => View(championshipService.GetAll());
        public async Task<IActionResult> AllDrivers() => View(driverService.GetAll());
        public async Task<IActionResult> AllNews() => View(newsService.GetAll());
        public async Task<IActionResult> NewsDetails(string Id) => View(newsService.NewsDetails(Id));
        public async Task<IActionResult> AllRaces() => View(raceService.GetAll());
        public async Task<IActionResult> AllTeams() => View(teamService.TeamsAndChampsBind());
    }
}
