using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Race;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class RaceController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly IRaceService raceService =new RaceService();

        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewRaceFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Date)) return Redirect("Add");

            var errors = validator.ValidateAddRace(model);

            if (errors.Count() == 0)
            {
                raceService.AddNewRace(model.Name, model.Date);
                return Redirect("/");
            }

            return View("./Error", errors);
        }
    }
}
