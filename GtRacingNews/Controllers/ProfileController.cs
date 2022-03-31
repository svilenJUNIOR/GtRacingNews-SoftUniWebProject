using GtRacingNews.Data.DataModels;
using GtRacingNews.Services;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRepository repository;
        private readonly IBindService bindService;
        private readonly UserManager<IdentityUser> userManager;
        public ProfileController(IRepository repository, UserManager<IdentityUser> userManager,
            IBindService bindService)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.bindService = bindService;
        }
       
        public async Task<IActionResult> MyTeams()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var teams = this.repository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = bindService.TeamBind(teams);

            return View(@"Views\All\AllTeams.cshtml", bindTeams);
        }

        public async Task<IActionResult> MyChampionships()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var champs = this.repository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = bindService.ChampionshipBind(champs);

            return View(@"Views\All\AllChampionships.cshtml", bindChamps);
        }

        public async Task<IActionResult> MyDrivers()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var drivers = this.repository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = bindService.DriverBind(drivers);

            return View(@"Views\All\AllDrivers.cshtml", bindDrivers);
        }

        public async Task<IActionResult> MyRaces()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var races = this.repository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = bindService.RaceBind(races);

            return View(@"Views\All\AllRaces.cshtml", bindRaces);
        }

        public async Task<IActionResult> MyNews()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var news = this.repository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindNews = bindService.NewsBind(news);

            return View(@"Views\All\AllNews.cshtml", bindNews);
        }
    }
}
