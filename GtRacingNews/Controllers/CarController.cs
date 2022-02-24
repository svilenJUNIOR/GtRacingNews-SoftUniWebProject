﻿using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService = new CarService();
        private readonly IValidator validator = new Validator();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewCarFormModel model)
        {
            var errors = validator.ValidateAddNewCar(model);

            if (errors.Count() == 0)
            {
                carService.AddNewCar(model.Model, model.ImageUrl);
                return Redirect("/");
            }
            
            return View("./Error", errors);
        }
    }
}
