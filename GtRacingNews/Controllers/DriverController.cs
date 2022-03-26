using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class DriverController : Controller
    {
        private readonly GTNewsDbContext context;

        public DriverController(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> All()
        {
            var driversTemp = context.Drivers.ToList();

            var drivers = context.Drivers
            .Select(x => new ViewAllDriversViewModel
            {
                DriverId = x.Id,
                Age = x.Age,
                Cup = x.Cup,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
            }).ToList();


            return View(drivers);
        }

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
    }
}
