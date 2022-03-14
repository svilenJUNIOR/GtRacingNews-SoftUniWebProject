using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly IValidator validator;
        private readonly IChampionshipService championshipService;
        private readonly GTNewsDbContext context;
        public ChampionshipController(IValidator validator, IChampionshipService championshipService, GTNewsDbContext context)
        {
            this.validator = validator;
            this.championshipService = championshipService;
            this.context = context;
        }

        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewChampionshipFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name)) return Redirect("Add");

            var errors = validator.ValidateAddNewChampionship(model);

            if (errors.Count() == 0)
            {
                championshipService.AddNewChampionship(model.Name, model.LogoUrl);
                return Redirect("/");
            }

            return View("./Error", errors);
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
