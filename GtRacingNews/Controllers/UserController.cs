using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly GTNewsDbContext context;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager, GTNewsDbContext context, IUserService userService, IValidator validator, IGuard guard)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.validator = validator;
            this.guard = guard;
            this.roleManager = roleManager;
            this.context = context;
        }
        public IActionResult Register() => View();
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            model.Email = model.Email.Trim();
            model.Password = model.Password.Trim();
            model.Username = model.Username.Trim();
            model.ConfirmPassword = model.ConfirmPassword.Trim();

            var formErrors = validator.ValidateUserFormRegister(ModelState);
            if (formErrors.Count() > 0) return View("./Error", formErrors);

            var dataErrors = validator.ValidateUserRegister(model);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else
            {
                await userManager.CreateAsync(userService.RegisterUser(model));
                await signInManager.SignInAsync(userService.RegisterUser(model), isPersistent: false);
            }
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Email, model.Password);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            model.Email = model.Email.Trim();
            model.Password = model.Password.Trim();

            var dataErrors = validator.ValidateUserLogin(model);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            var loggedInUser = await this.userManager.FindByEmailAsync(model.Email);
            await this.signInManager.SignInAsync(loggedInUser, true);

            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return Redirect("/");
        }
    }
}
