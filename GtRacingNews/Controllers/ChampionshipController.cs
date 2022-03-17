using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Team;
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

        [Authorize]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewChampionshipFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.LogoUrl);
            var dataErrors = validator.ValidateAddNewChampionship(model);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else await championshipService.AddNewChampionship(model.Name, model.LogoUrl); return Redirect("/");
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
