using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly IValidator validator;
        private readonly IChampionshipService championshipService;
        private readonly IGuard guard;
        private readonly GTNewsDbContext context;
        public ChampionshipController(IValidator validator, IChampionshipService championshipService, 
            GTNewsDbContext context, IGuard guard)
        {
            this.validator = validator;
            this.championshipService = championshipService;
            this.context = context;
            this.guard = guard;
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
