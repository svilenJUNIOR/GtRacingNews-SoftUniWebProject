using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Race;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class RaceController : Controller
    {
        private readonly IValidator validator;
        private readonly IRaceService raceService;
        private readonly GTNewsDbContext context;

        public RaceController(IValidator validator, IRaceService raceService, GTNewsDbContext context)
        {
            this.validator = validator;
            this.raceService = raceService;
            this.context = context;
        }

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

        public async Task<IActionResult> All()
        {
            var races = context.Races
                .Select(x => new ViewAllRacesViewModel
                {
                    Date = x.Date,
                    Name = x.Name,
                });

            return View(races);
        }
    }
}
