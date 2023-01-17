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

        private readonly UserManager<IdentityUser> userManager;

        public ProfileController(ISqlRepository sqlRepository, IBindService bindService, IDeleteService deleteService, UserManager<IdentityUser> userManager)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
            this.deleteService = deleteService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyProfile()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var userProfile = sqlRepository.FindByUserId(currentUser.Id);

            var model = bindService.ProfileBind(currentUser, userProfile);

            return View(model);
        }

        public async Task<IActionResult> Delete(string collection, string Id)
        {
            await deleteService.Delete(collection, Id);
            return Redirect("MyProfile");
        }

        public async Task<IActionResult> Edit(string collection, string Id)
        {
            return View();
        }
    }
}
