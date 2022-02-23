﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly IUserService userService = new UserService();

        //private readonly UserManager<User> userManager;
        //private readonly SignInManager<User> signInManager;
        //private readonly RoleManager<IdentityRole> roleManager;

        //public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        //{
        //    this.userManager = userManager;
        //    this.signInManager = signInManager;
        //    this.roleManager = roleManager;
        //}

        public async Task<IActionResult> Register(RegisterUserFormModel model)
        {
            var errors = validator.ValidateUserRegistration(model);

            if (errors.Count() == 0)
            {
                userService.RegisterUser(model.Email, model.Password, model.Username);

                return Redirect("/");
            }
            // use identity to complete
            return View("./Error", errors);
        }

        //public async Task<IActionResult> Login(LoginUserFormModel model)
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    return View();
        //}
    }
}