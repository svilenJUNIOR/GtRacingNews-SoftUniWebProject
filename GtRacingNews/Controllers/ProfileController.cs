using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private ISqlRepository sqlRepository;
        private IBindService bindService;
        private IEditService editService;

        private readonly UserManager<IdentityUser> userManager;

        public ProfileController(ISqlRepository sqlRepository, IBindService bindService,
           IEditService editService, UserManager<IdentityUser> userManager)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
            this.userManager = userManager;
            this.editService = editService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var userProfile = sqlRepository.FindByUserId(currentUser.Id);

            var model = bindService.ProfileBind(currentUser, userProfile);

            return View(model);
        }

        public async Task<IActionResult> EditPersonal()
        {
            var userName = this.User.Identity.Name;
            var user = await this.userManager.FindByNameAsync(userName);
            var id = user.Id;

            return View(this.sqlRepository.FindByUserId(id));
        }
        public async Task<IActionResult> EditTeam(string Id)
         => View(this.bindService.BindTeamForEdit(Id));

        public async Task<IActionResult> EditDriver(string Id)
        => View(this.bindService.BindDriverForEdit(Id));

        public async Task<IActionResult> EditChampionship(string Id)
        => View(this.sqlRepository.FindById<Championship>(Id));

        public async Task<IActionResult> EditNews(string Id)
        => View(this.sqlRepository.FindById<News>(Id));

        public async Task<IActionResult> EditRace(string Id)
        => View(this.sqlRepository.FindById<Race>(Id));

        [HttpPost]
        public async Task<IActionResult> EditTeam(string Id, AddTeamFormModel data)
        {
            this.editService.EditTeam(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditDriver(string Id, AddNewDriverFormModel data)
        {
            this.editService.EditDriver(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditRace(string Id, AddNewRaceFormModel data)
        {
            this.editService.EditRace(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditNews(string Id, AddNewFormModel data)
        {
            this.editService.EditNews(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditChampionship(string Id, AddNewChampionshipFormModel data)
        {
            this.editService.EditChampionship(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditPersonal(CreatePremiumFormModel data)
        {
            var userName = this.User.Identity.Name;
            var user = await this.userManager.FindByNameAsync(userName);
            var Id = user.Id;

            this.editService.EditProfileInfo(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }
    }
}
