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
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult AddToRole()
        {
            var model = new RoleToUserViewModel();

            var roles = roleManager.Roles.Select(x => x.Name).ToList();
            var users = userManager.Users.Select(x => x.UserName).ToList();

            model.Users = users;
            model.Roles = roles;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(RoleToUserViewModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.User);
            var role = await this.roleManager.FindByNameAsync(model.Role);

            if (this.User.IsInRole(model.Role)) return View("./Error", "User is already in this role.");

            await this.userManager.AddToRoleAsync(user, model.Role);

            return Redirect("/");
        }
    }
}
