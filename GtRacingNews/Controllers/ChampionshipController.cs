using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly IChampionshipService championshipService = new ChampionshipService();
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
    }
}
