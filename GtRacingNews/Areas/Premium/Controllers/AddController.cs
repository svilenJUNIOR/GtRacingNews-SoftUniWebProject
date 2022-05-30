using GtRacingNews.Data.DataModels.SqlModels;
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
        private readonly IEngine engine;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AddController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IEngine engine)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.engine = engine;
        }
        private async Task<IdentityUser> user()
            => await this.userManager.FindByNameAsync(this.User.Identity.Name);

        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddTeam()
        {
            AddTeamFormModel model = new AddTeamFormModel();

            var championships = engine.sqlRepository.GettAll<Championship>().ToList();

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
            var teams = engine.sqlRepository.GettAll<Team>().Where(x => x.Drivers.Count() < 3).ToList();
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

            var result = await engine.AddTeam(isModerator, this.user().Result.Id, model, "Team", ModelState);
            if (result.Count() > 0) return View("./Error", result);

            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddNews(AddNewFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            var result = await engine.AddNews(isModerator, this.user().Result.Id, model, "News", ModelState);
            if (result.Count() > 0) return View("./Error", result);

            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddRace(AddNewRaceFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            var result = await engine.AddRace(isModerator, this.user().Result.Id, model, "Race", ModelState);
            if (result.Count() > 0) return View("./Error", result);

            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddDriver(AddNewDriverFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            var result = await engine.AddDriver(isModerator, this.user().Result.Id, model, "Driver", ModelState);
            if (result.Count() > 0) return View("./Error", result);

            return Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddChampionship(AddNewChampionshipFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            var result = await engine.AddChampionship(isModerator, this.user().Result.Id, model, "Championship", ModelState);
            if (result.Count() > 0) return View("./Error", result);

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
