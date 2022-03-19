using GtRacingNews.Data.DBContext;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly GTNewsDbContext context;
        public ChampionshipController(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> All()
        {
            var championships = context.Championships
                .Select(x => new ViewAllChampionshipsViewModel
                {
                    ChampionshipId = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    Teams = context.Teams.Where(t => t.ChampionshipId == x.Id).Select(t => t.Name).ToList()
                }).ToList();

            return View(championships);
        }
    }
}
