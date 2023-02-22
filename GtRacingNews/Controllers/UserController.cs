using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GtRacingNews.Common.Constants;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.Services.User;
using GtRacingNews.Services.Profiles;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        private IGuard guard;
        private IUserService userService;
        private IProfileService profileService;

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager, IGuard guard, IUserService userService,
            IProfileService profileService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.guard = guard;
            this.userService = userService;
            this.profileService = profileService;
        }
        public IActionResult Register() => View();
        public IActionResult Login() => View();
        public IActionResult Profile()
        {
            var roles = this.roleManager.Roles.ToList();
            var model = this.profileService.AddRolesToModel(roles);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserFormModel model)
        {
            try
            {
                var dataErrors = guard.ValidateUserRegister(model, ModelState);

                model.Email = model.Email.Trim();
                model.Password = model.Password.Trim();
                model.Username = model.Username.Trim();
                model.ConfirmPassword = model.ConfirmPassword.Trim();

                await userManager.CreateAsync(userService.RegisterUser(model));
                await signInManager.SignInAsync(userService.RegisterUser(model), isPersistent: false);

                return Redirect("/");
            }
            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserFormModel model)
        {
            try
            {
                var dataErrors = guard.ValidateUserLogin(model);

                model.Email = model.Email.Trim();
                model.Password = model.Password.Trim();

                var loggedInUser = await this.userManager.FindByEmailAsync(model.Email);
                await this.signInManager.SignInAsync(loggedInUser, true);

                CookieOptions cookieOptions = new CookieOptions();

                cookieOptions.Secure = true;
                cookieOptions.Expires = DateTime.Now.AddDays(3);

                // UserCookieKey comes from Common.Constants
                Response.Cookies.Append(Values.UserCookieKey, model.Email, cookieOptions);

                return Redirect("/");
            }
            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Profile(CreatePremiumFormModel model)
        {
            try
            {
                var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
                await this.userManager.AddToRoleAsync(currentUser, model.Role);

                await this.profileService.AddNewProfile(model, ModelState,currentUser.Id);
               
                return Redirect("/");
            }
            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return View("./Error", errors);
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Secure = true;
            cookieOptions.Expires = DateTime.Now.AddDays(-3);

            // UserCookieKey comes from Common.Constants
            Response.Cookies.Delete(Values.UserCookieKey, cookieOptions);

            return Redirect("/");
        }
    }
}
