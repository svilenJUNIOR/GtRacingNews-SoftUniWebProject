using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private ISqlRepository sqlRepository;
        private IBindService bindService;
        private IDeleteService deleteService;
        private IEditService editService;

        private readonly UserManager<IdentityUser> userManager;

        public ProfileController(ISqlRepository sqlRepository, IBindService bindService, 
            IDeleteService deleteService, IEditService editService, UserManager<IdentityUser> userManager)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
            this.deleteService = deleteService;
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

        //public async Task<IActionResult> Delete(string collection, string Id)
        //{
        //    await deleteService.Delete<>(collection, Id);
        //    return Redirect("MyProfile");
        //}

        public async Task<IActionResult> EditTeam(string Id)
        {
            this.editService.EditObject<Team>(Id);
            return View();
        }
        public async Task<IActionResult> EditDriver(string Id)
        {
            this.editService.EditObject<Driver>(Id);
            return View();
        }

        public async Task<IActionResult> EditChampionship(string Id)
        {
            this.editService.EditObject<Championship>(Id);
            return View();
        }

        public async Task<IActionResult> EditNews(string Id)
        {
            this.editService.EditObject<News>(Id);
            return View();
        }

        public async Task<IActionResult> EditRace(string Id)
        {
            this.editService.EditObject<Race>(Id);
            return View();
        }
    }
}
