using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GtRacingNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private ISqlSeeder seeder;
        public HomeController(ILogger<HomeController> logger, ISqlSeeder seeder)
        {
            this.logger = logger;
            this.seeder = seeder;
        }

        public async Task<IActionResult> Seed()
        {

            await this.seeder.SeedUser();
            await this.seeder.SeedRoles();
            await this.seeder.SeedUserRoles();

            await this.seeder.SeedChampionship();
            await this.seeder.SeedTeams();
            await this.seeder.SeedDriver();
            await this.seeder.SeedNews();
            await this.seeder.SeedComments();
            await this.seeder.SeedRaces();
            await this.seeder.SeedProfiles();

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