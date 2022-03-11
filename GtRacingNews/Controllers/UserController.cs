using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService = new UserService();

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
            await userManager.CreateAsync(userService.RegisterUser(model));
            return Redirect("/");
        }

        public ActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserFormModel model)
        {
            var loggedInUser = await this.userManager.FindByEmailAsync(model.Email);

            if (loggedInUser != null) await this.signInManager.SignInAsync(loggedInUser, true);

            return Redirect("/");
        }
    }
}
