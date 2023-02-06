﻿using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Championships;
using GtRacingNews.Services.Comments;
using GtRacingNews.Services.Drivers;
using GtRacingNews.Services.Newss;
using GtRacingNews.Services.Profiles;
using GtRacingNews.Services.Races;
using GtRacingNews.Services.Teams;
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
        private readonly ISqlRepository sqlRepository;

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private IProfileService profileService;
        private IChampionshipService championshipService;
        private ICommentService commentService;
        private IDriverService driverService;
        private INewsService newsService;
        private IRaceService raceService;
        private ITeamService teamService;

        public AddController(ISqlRepository sqlRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IProfileService profileService, IChampionshipService championshipService, ICommentService commentService, IDriverService driverService, INewsService newsService, IRaceService raceService, ITeamService teamService)
        {
            this.sqlRepository = sqlRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.profileService = profileService;
            this.championshipService = championshipService;
            this.commentService = commentService;
            this.driverService = driverService;
            this.newsService = newsService;
            this.raceService = raceService;
            this.teamService = teamService;
        }

        private async Task<IdentityUser> user() => await this.userManager.FindByNameAsync(this.User.Identity.Name);

        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddTeam()
        {
            AddTeamFormModel model = new AddTeamFormModel();

            var championships = sqlRepository.GettAll<Championship>().ToList();
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
            var teams = sqlRepository.GettAll<Team>().Where(x => x.Drivers.Count() < 3).ToList();

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

            try
            {
                var result = await teamService.Add(isModerator, this.user().Result.Id, model, "Team", ModelState);
                return Redirect("/");
            }
            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddNews(AddNewFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            try
            {
                var result = await newsService.AddNews(isModerator, this.user().Result.Id, model, "News", ModelState);
                return Redirect("/");

            }
            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddRace(AddNewRaceFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            try
            {
                var result = await raceService.AddRace(isModerator, this.user().Result.Id, model, "Race", ModelState);
                return Redirect("/");
            }

            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddDriver(AddNewDriverFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            try
            {
                var result = await driverService.AddDriver(isModerator, this.user().Result.Id, model, "Driver", ModelState);
                return Redirect("/");
            }

            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> AddChampionship(AddNewChampionshipFormModel model)
        {
            bool isModerator = this.User.IsInRole("Moderator");

            try
            {
                var result = await championshipService.AddChampionship(isModerator, this.user().Result.Id, model, "Championship", ModelState);
                return Redirect("/");
            }

            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
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
