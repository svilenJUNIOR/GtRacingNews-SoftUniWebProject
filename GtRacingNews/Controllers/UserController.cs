﻿using GtRacingNews.Services.Contracts;
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

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager, IUserService userService, IValidator validator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.validator = validator;
            this.roleManager = roleManager;
        }
        public IActionResult Register() => View();
        public IActionResult Login() => View();

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
    }
}
