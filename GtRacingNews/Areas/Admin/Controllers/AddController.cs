using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Role;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AddController : Controller
    {
        private readonly IValidator validator;
        private readonly IAddService addService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly GTNewsDbContext context;

        public AddController(IValidator validator, IAddService addService, GTNewsDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            this.validator = validator;
            this.addService = addService;
            this.context = context;
            this.roleManager = roleManager;
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
        public IActionResult AddRole() => View();

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
            var nullErrors = validator.AgainstNull(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
            var dataErrors = validator.ValidateObject("Team", model.Name, ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            await addService.AddNewTeam(typeof(Team), model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNews(AddNewFormModel model)
        {
            var nullErrors = validator.AgainstNull(model.Heading, model.Description, model.PictureUrl);
            var dataErrors = validator.ValidateObject("News", model.Heading, ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            await addService.AddNews(typeof(News), model.Heading, model.Description, model.PictureUrl); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRace(AddNewRaceFormModel model)
        {
            var nullErrors = validator.AgainstNull(model.Name, model.Date);
            var dataErrors = validator.ValidateObject("Race", model.Name, ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await addService.AddNewRace(typeof(Race), model.Name, model.Date); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDriver(AddNewDriverFormModel model)
        {
            var nullErrors = validator.AgainstNull(model.TeamName, model.Age.ToString(), model.ImageUrl, model.Cup);
            var dataErrors = validator.ValidateObject("Driver", model.Name, ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else await addService.AddNewDriver(typeof(Driver), model.Name, model.Cup, model.ImageUrl, model.Age, model.TeamName); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddChampionship(AddNewChampionshipFormModel model)
        {
            var nullErrors = validator.AgainstNull(model.Name, model.LogoUrl);
            var dataErrors = validator.ValidateObject("Championship", model.Name, ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else await addService.AddNewChampionship(typeof(Championship), model.Name, model.LogoUrl); return Redirect("/Admin/Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(AddNewRoleFormModel model)
        {
            if (model.Name is null) return View();
            if (roleManager.Roles.Any(x => x.NormalizedName == model.Name.ToUpperInvariant()))
                return View("./Error", new string[] { "Role with that name already exists" });

            var role = new IdentityRole();
            role.Name = model.Name;

            await this.roleManager.CreateAsync(role);
            return Redirect("/Admin/Home");
        }
    }
}
