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
        private readonly IValidator validator = new Validator();
        private readonly IChampionshipService championshipService = new ChampionshipService();
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewChampionshipFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name)) return Redirect("Add");

            var errors = validator.ValidateAddNewChampionship(model);

            if (errors.Count() == 0)
            {
                championshipService.AddNewChampionship(model.Name);
                return Redirect("/");
            }

            return View("./Error", errors);
        }

        public async Task<IActionResult> All()
        {
            var championships = context.Championships
                .Select(x => new ViewAllChampionshipsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                });

            return View(championships);
        }

        public async Task<IActionResult> Details(int id)
        {
            var championship = context.Championships
                .Where(x => x.Id == id)
                .Select(x => new ChampionshipDetailsViewModel
                {
                    TeamName = x.Teams.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault()
                }).ToList();

            return View(championship);
        }
    }
}
