using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Team;
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
        public async Task<IActionResult> EditTeam(string Id)
         => View(this.bindService.BindTeamForEdit(Id));

        [HttpPost]
        public async Task<IActionResult> EditTeam(string Id, AddTeamFormModel data)
        {
            this.editService.EditTeam(Id, data);
            return RedirectToAction("MyProfile", "Profile");
        }

        //public async Task<IActionResult> EditDriver(string Id)
        //=> View(this.editService.EditObject<Driver>(Id));

        //public async Task<IActionResult> EditChampionship(string Id)
        //=> View(this.editService.EditObject<Championship>(Id));

        //public async Task<IActionResult> EditNews(string Id)
        //=> View(this.editService.EditObject<News>(Id));

        //public async Task<IActionResult> EditRace(string Id)
        //=> View(this.editService.EditObject<Race>(Id));
    }
}
