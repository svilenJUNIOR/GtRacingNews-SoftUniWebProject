using GtRacingNews.Data.DataModels;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public ActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserFormModel model)
        {
            var user = new IdentityUser();
            user.Email = model.Email;
            user.UserName = model.Username;
            user.PasswordHash = model.Password;


            var result = await this.userManager.CreateAsync(user);

            return Redirect("/");
        }
    }
}
