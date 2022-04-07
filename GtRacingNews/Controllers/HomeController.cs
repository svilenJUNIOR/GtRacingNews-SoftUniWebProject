using GtRacingNews.Models;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GtRacingNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeederService seederService;
        public HomeController(ILogger<HomeController> logger, ISeederService seederService)
        {
            _logger = logger;
            this.seederService = seederService;
        }

        public async Task<IActionResult> Seed()
        {
            await seederService.SeedUser();
            await seederService.SeedRoles();
            await seederService.SeedUserRoles();

            await seederService.SeedChampionship();
            await seederService.SeedTeams();
            await seederService.SeedDriver();
            await seederService.SeedNews();
            await seederService.SeedComments();
            await seederService.SeedRaces();
            await seederService.SeedProfiles();

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