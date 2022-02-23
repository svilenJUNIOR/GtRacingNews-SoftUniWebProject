using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class TeamController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly ITeamService teamService = new TeamService();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name)) return Redirect("Add");

            var errors = validator.ValidateAddNewTeam(model);

            if (errors.Count() == 0)
            {
                teamService.AddNewTeam(model.Name);
                return Redirect("/");
            }

            return View("./Error", errors);
        }
    }
}
