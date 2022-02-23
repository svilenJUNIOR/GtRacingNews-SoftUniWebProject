using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService = new CarService();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewCarFormModel model)
        {
            if (string.IsNullOrEmpty(model.Model) || string.IsNullOrEmpty(model.ImageUrl)) return Redirect("Add");

            carService.AddNewCar(model.Model, model.ImageUrl);
            return Redirect("/");
        }
    }
}
