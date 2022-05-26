using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEngine engine;
        public ProfileController(IEngine engine, UserManager<IdentityUser> userManager)
        {
            this.engine = engine;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyProfile()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var userProfile = engine.sqlRepository.FindProfileByUserId(currentUser.Id);

            var model = engine.profileService.ProfileBind(currentUser, userProfile);

            return View(model);
        }

        public async Task<IActionResult> Delete(string collection, string Id)
        {
            await engine.deleteService.Delete(collection, Id);
            return Redirect("MyProfile");
        }
    }
}
