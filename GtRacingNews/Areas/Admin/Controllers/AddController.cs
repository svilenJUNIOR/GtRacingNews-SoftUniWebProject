using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AddController : Controller
    {
        private readonly IValidator validator;
        private readonly IGuard guard;

        private readonly ITeamService teamService;
        private readonly INewsService newsService;
        private readonly IRaceService raceService;
        private readonly IDriverService driverService;
        private readonly IChampionshipService championshipService;

        private readonly GTNewsDbContext context;

        public AddController(IValidator validator, ITeamService teamService, IGuard guard, INewsService newsService,
            IRaceService raceService, IDriverService driverService, IChampionshipService championshipService,
               GTNewsDbContext context)
        {
            this.validator = validator;
            this.guard = guard;

            this.teamService = teamService;
            this.newsService = newsService;
            this.raceService = raceService;
            this.driverService = driverService;
            this.championshipService = championshipService;

            this.context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTeam()
        {
            AddTeamFormModel model = new AddTeamFormModel();

            var championships = context.Championships.ToList();

            model.Championships = championships;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddNews() => View();

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRace() => View();

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDriver()
        {
            var teams = context.Teams.Where(x => x.Drivers.Count() < 3).ToList();
            AddNewDriverFormModel model = new AddNewDriverFormModel();
            model.Teams = teams;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddChampionship() => View();


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTeam(AddTeamFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
            var dataErrors = validator.ValidateAddNewTeam(model);
            var formErrors = validator.ValidateAddTeamForm(model);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (formErrors.Count() > 0) return View("./Error", formErrors);

            else await teamService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNews(AddNewFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Heading, model.Description, model.PictureUrl);
            var dataErrors = validator.ValidateAddNews(model);
            var formErrors = validator.ValidateForm(ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (formErrors.Count() > 0) return View("./Error", formErrors);

            else await newsService.AddNews(model.Heading, model.Description, model.PictureUrl); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRace(AddNewRaceFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.Date);
            var dataErrors = validator.ValidateAddRace(model);
            var formErrors = validator.ValidateForm(ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (formErrors.Count() > 0) return View("./Error", formErrors);

            else await raceService.AddNewRace(model.Name, model.Date); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDriver(AddNewDriverFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.TeamName, model.Age.ToString(), model.ImageUrl, model.Cup);
            var dataErrors = validator.ValidateAddNewDriver(model);
            var formErrors = validator.ValidateForm(ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (formErrors.Count() > 0) return View("./Error", formErrors);

            else await driverService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age, model.TeamName); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddChampionship(AddNewChampionshipFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.LogoUrl);
            var dataErrors = validator.ValidateAddNewChampionship(model);
            var formErrors = validator.ValidateForm(ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (formErrors.Count() > 0) return View("./Error", formErrors);

            else await championshipService.AddNewChampionship(model.Name, model.LogoUrl); return Redirect("/Admin/Home");
        }
    }
}
