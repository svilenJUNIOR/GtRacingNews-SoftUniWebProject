using GtRacingNews.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager) => this.userManager = userManager;
        public IActionResult AddToRole()
        {
            var model = new RoleToUserViewModel();
            var users = userManager.Users.Select(x => x.UserName).ToList();
            model.Users = users;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(RoleToUserViewModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.User);

            await this.userManager.AddToRoleAsync(user, "Admin");

            return Redirect("/");
        }
    }
}
