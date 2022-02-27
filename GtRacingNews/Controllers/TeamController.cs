using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class TeamController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly ITeamService teamService = new TeamService();
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.CarModel) || string.IsNullOrEmpty(model.LogoUrl)) return Redirect("Add");

            var errors = validator.ValidateAddNewTeam(model);

            if (errors.Count() == 0)
            {
                teamService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl);
                return Redirect("/");
            }

            return View("./Error", errors);
        }

        public async Task<IActionResult> All()
        {
            var teams = context.Teams
                .Select(x => new ViewAllTeamsViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    LogoUrl = x.LogoUrl,
                });

            return View(teams);
        }

        public async Task<IActionResult> AddToChampionship() => View();

        [HttpPost]
        public async Task<IActionResult> AddToChampionship(int id, AddChampionshipToTeamFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name)) return Redirect("AddToChampionship");

            var errors = validator.ValidateChampionshipToTeam(model);

            if (errors.Count() == 0)
            {
                teamService.AddTeamToChampionship(id, model.Name);
                return Redirect("/");
            }

            return View("./Error", errors);
        }
    }
}