using GtRacingNews.Data.DataModels;
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
        private readonly IAddService addService;

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager, IUserService userService, IValidator validator,
            IAddService addService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.validator = validator;
            this.roleManager = roleManager;
            this.addService = addService;
        }
        public IActionResult Register() => View();
        public IActionResult Login() => View();
        public IActionResult ChangePassword() => View();
        public IActionResult ForgotPassword() => View();
        public IActionResult Profile()
        {
            CreatePremiumFormModel model = new CreatePremiumFormModel();

            var roles = this.roleManager.Roles.Where(x => x.Name != "User").Select(x => x.Name).ToList();

            model.Roles = roles;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserFormModel model)
        {
            var nullErrors = validator.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            model.Email = model.Email.Trim();
            model.Password = model.Password.Trim();
            model.Username = model.Username.Trim();
            model.ConfirmPassword = model.ConfirmPassword.Trim();

            var formErrors = validator.ValidateForm(ModelState);
            var dataErrors = validator.ValidateUserRegister(model);

            if (formErrors.Count() > 0) return View("./Error", formErrors);
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
            var nullErrors = validator.AgainstNull(model.Email, model.Password);
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


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Profile(CreatePremiumFormModel model)
        {
            var nullErrors = validator.AgainstNull(model.Address, model.Age.ToString());
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            await this.userManager.AddToRoleAsync(currentUser, model.Role);

            await this.addService.AddNewProfile(model.Address, model.Age, currentUser.Id, model.Role);
            return Redirect("/");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordFormModel model)
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordFormModel model)
        {
            return View();
        }
    }
}
