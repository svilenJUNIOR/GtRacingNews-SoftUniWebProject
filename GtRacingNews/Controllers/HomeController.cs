using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GtRacingNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEngine engine;
        public HomeController(ILogger<HomeController> logger,IEngine engine)
        {
            this.logger = logger;
            this.engine = engine;
        }

        public async Task<IActionResult> Seed()
        {

            //await this.engine.seeder.SeedUser();
            await this.engine.seeder.SeedRoles();
            await this.engine.seeder.SeedUserRoles();

            await this.engine.seeder.SeedChampionship();
            await this.engine.seeder.SeedTeams();
            await this.engine.seeder.SeedDriver();
            await this.engine.seeder.SeedNews();
            await this.engine.seeder.SeedComments();
            await this.engine.seeder.SeedRaces();
            await this.engine.seeder.SeedProfiles();

            return Redirect("/");
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole("Admin")) return Redirect("Admin/Home");

            if (this.User.Identity.IsAuthenticated == false) return Redirect("Guest/Home");

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}