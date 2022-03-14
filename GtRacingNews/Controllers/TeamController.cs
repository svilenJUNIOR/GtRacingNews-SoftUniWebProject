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
        private readonly IValidator validator;
        private readonly ITeamService teamService;
        private readonly GTNewsDbContext context;
        private readonly IGuard guard;

        public TeamController(IValidator validator, ITeamService teamService, IGuard guard, GTNewsDbContext context)
        {
            this.validator = validator;
            this.teamService = teamService;
            this.context = context;
            this.guard = guard;
        }

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
            var nullErrors = guard.AgainstNull(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
            var dataErrors = validator.ValidateAddNewTeam(model);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else teamService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName); return Redirect("/");
        }

        public async Task<IActionResult> All()
        {
            var teams = context.Teams
                .Select(x => new ViewAllTeamsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    CarModel = x.CarModel,
                    Drivers = context.Drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList()
                }).ToList();

            return View(teams);
        }
    }
}