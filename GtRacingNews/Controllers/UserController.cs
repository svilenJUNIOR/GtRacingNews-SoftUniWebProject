using GtRacingNews.Common.Constants;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator validator;
        private readonly IGuard guard;

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            IUserService userService, IValidator validator, IGuard guard)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.validator = validator;
            this.guard = guard;
        }
        public IActionResult Register() => View();
        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            var isEmailValid = guard.AgainstInvalidEmail(model.Email);
            var dataErrors = validator.ValidateUserRegister(ModelState);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            else if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            else if (isEmailValid) return View("./Error", "Email must end with @email.com");

            else await userManager.CreateAsync(userService.RegisterUser(model)); return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Email, model.Password);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            var loggedInUser = await this.userManager.FindByEmailAsync(model.Email);

            if (loggedInUser == null) return View(" ", Messages.UnExistingUser);

            else await this.signInManager.SignInAsync(loggedInUser, true); return Redirect("/");
        }
    }
}
