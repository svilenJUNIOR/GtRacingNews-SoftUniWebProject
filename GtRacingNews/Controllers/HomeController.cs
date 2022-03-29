using GtRacingNews.Models;
using GtRacingNews.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GtRacingNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        public async Task<IActionResult> testov()
        {
            var seed = new Seeder();

            await seed.SeedUser();
            await seed.SeedRoles();
            await seed.SeedUserRoles();

            await seed.SeedChampionship();
            await seed.SeedTeams();
            await seed.SeedDriver();
            await seed.SeedNews();
            await seed.SeedComments();
            await seed.SeedRaces();

            return Redirect("/");
        }

        public IActionResult Index()
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