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
        private readonly IGuard guard;

        public RaceController(IValidator validator, IRaceService raceService, GTNewsDbContext context, IGuard guard)
        {
            this.validator = validator;
            this.raceService = raceService;
            this.context = context;
            this.guard = guard;
        }

        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewRaceFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.Date);
            var dataErrors = validator.ValidateAddRace(model);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else raceService.AddNewRace(model.Name, model.Date); return Redirect("/");
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
