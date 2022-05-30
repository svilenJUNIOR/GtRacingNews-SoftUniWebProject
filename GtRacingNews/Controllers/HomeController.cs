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
            MongoDbContext context = new MongoDbContext();
            context.delete();
            context.create();


            await this.engine.mongoSeeder.SeedChampionship();
            await this.engine.mongoSeeder.SeedTeams();
            await this.engine.mongoSeeder.SeedDriver();
            await this.engine.mongoSeeder.SeedNews();
            await this.engine.mongoSeeder.SeedComments();
            await this.engine.mongoSeeder.SeedRaces();
            await this.engine.mongoSeeder.SeedProfiles();

            //await this.engine.SqlSeeder.SeedUser();
            //await this.engine.SqlSeeder.SeedRoles();
            //await this.engine.SqlSeeder.SeedUserRoles();

            //await this.engine.SqlSeeder.SeedChampionship();
            //await this.engine.SqlSeeder.SeedTeams();
            //await this.engine.SqlSeeder.SeedDriver();
            //await this.engine.SqlSeeder.SeedNews();
            //await this.engine.SqlSeeder.SeedComments();
            //await this.engine.SqlSeeder.SeedRaces();
            //await this.engine.SqlSeeder.SeedProfiles();

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