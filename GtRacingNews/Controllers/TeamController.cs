using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class TeamController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly ITeamService teamService = new TeamService();
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public async Task<IActionResult> Add()
        {
            AddTeamFormModel model = new AddTeamFormModel();

            var championships = context.Championships.ToList();

            model.Championships = championships;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.CarModel) || string.IsNullOrEmpty(model.LogoUrl)) return Redirect("Add");

            var errors = validator.ValidateAddNewTeam(model);

            if (errors.Count() == 0)
            {
                teamService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
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
                    TeamId = x.Id,
                    LogoUrl = x.LogoUrl,
                }).ToList();

            return View(teams);
        }
    }
}