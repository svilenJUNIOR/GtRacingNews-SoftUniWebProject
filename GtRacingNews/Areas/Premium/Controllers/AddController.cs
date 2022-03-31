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

namespace GtRacingNews.Areas.Premium.Controllers
{
    [Area("Premium")]
    [Authorize(Roles = "Moderator, Admin")]
    public class AddController : Controller
    {
        private readonly IValidator validator;
        private readonly IAddService addService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly GTNewsDbContext context;
        public AddController(IValidator validator, IAddService addService, GTNewsDbContext context,
            RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.validator = validator;
            this.addService = addService;
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddTeam()
        {
            AddTeamFormModel model = new AddTeamFormModel();

            var championships = context.Championships.ToList();

            model.Championships = championships;

            return View(model);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public IActionResult AddNews() => View();

        [Authorize(Roles = "Moderator, Admin")]
        public IActionResult AddRole() => View();

        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddRace() => View();

        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddDriver()
        {
            var teams = context.Teams.Where(x => x.Drivers.Count() < 3).ToList();
            AddNewDriverFormModel model = new AddNewDriverFormModel();
            model.Teams = teams;
            return View(model);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddChampionship() => View();


        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddTeam(AddTeamFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var nullErrors = validator.AgainstNull(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
            var dataErrors = validator.ValidateObject("Team", model.Name, ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            await addService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName, isModerator, user.Id); 
            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddNews(AddNewFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var nullErrors = validator.AgainstNull(model.Heading, model.Description, model.PictureUrl);
            var dataErrors = validator.ValidateObject("News", model.Heading, ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            await addService.AddNews(model.Heading, model.Description, model.PictureUrl, isModerator, user.Id);
            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddRace(AddNewRaceFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var nullErrors = validator.AgainstNull(model.Name, model.Date);
            var dataErrors = validator.ValidateObject("Race", model.Name, ModelState);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await addService.AddNewRace(model.Name, model.Date, isModerator, user.Id);
            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddDriver(AddNewDriverFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var nullErrors = validator.AgainstNull(model.TeamName, model.Age.ToString(), model.ImageUrl, model.Cup);
            var dataErrors = validator.ValidateObject("Driver", model.Name, ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else await addService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age, model.TeamName, isModerator, user.Id);
            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddChampionship(AddNewChampionshipFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var nullErrors = validator.AgainstNull(model.Name, model.LogoUrl);
            var dataErrors = validator.ValidateObject("Championship", model.Name, ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else await addService.AddNewChampionship(model.Name, model.LogoUrl, isModerator, user.Id);
            return Redirect("/");
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
