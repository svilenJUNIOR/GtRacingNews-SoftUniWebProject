using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        private readonly IEngine engine;

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager, IEngine engine)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.engine = engine;
            this.roleManager = roleManager;
        }
        public IActionResult Register() => View();
        public IActionResult Login() => View();
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
            var nullErrors = engine.validator.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            model.Email = model.Email.Trim();
            model.Password = model.Password.Trim();
            model.Username = model.Username.Trim();
            model.ConfirmPassword = model.ConfirmPassword.Trim();

            var formErrors = engine.validator.ValidateForm(ModelState);
            var dataErrors = engine.validator.ValidateUserRegister(model);

            if (formErrors.Count() > 0) return View("./Error", formErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else
            {
                await userManager.CreateAsync(engine.userService.RegisterUser(model));
                await signInManager.SignInAsync(engine.userService.RegisterUser(model), isPersistent: false);
            }
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserFormModel model)
        {
            var nullErrors = engine.validator.AgainstNull(model.Email, model.Password);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            model.Email = model.Email.Trim();
            model.Password = model.Password.Trim();

            var dataErrors = engine.validator.ValidateUserLogin(model);
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
            var nullErrors = engine.validator.AgainstNull(model.Address, model.Age.ToString());
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            await this.userManager.AddToRoleAsync(currentUser, model.Role);

            await this.engine.addService.AddNewProfile(model.Address, model.Age, currentUser.Id, model.Role, model.ProfilePicture);
            return Redirect("/");
        }
    }
}
