using GtRacingNews.Data.DBContext;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class TeamController : Controller
    {
        private readonly GTNewsDbContext context;

        public TeamController(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> All()
        {
            var teams = context.Teams
                .Select(x => new ViewAllTeamsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    CarModel = x.CarModel,
                    Drivers = context.Drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList()
                }).ToList();

            return View(teams);
        }
    }
}