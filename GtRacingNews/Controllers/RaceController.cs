using GtRacingNews.Data.DBContext;
using GtRacingNews.ViewModels.Race;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class RaceController : Controller
    {
        private readonly GTNewsDbContext context;

        public RaceController(GTNewsDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            var races = context.Races
                .Select(x => new ViewAllRacesViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                });

            return View(races);
        }
    }
}
