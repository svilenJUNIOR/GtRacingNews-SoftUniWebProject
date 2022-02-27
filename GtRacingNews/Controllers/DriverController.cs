using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class DriverController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly IDriverService driverService= new DriverService();
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewDriverFormModel model)
        {
            if (model.Age == null || string.IsNullOrEmpty(model.ImageUrl)
                || string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Cup)) return Redirect("Add");

            var errors = validator.ValidateAddNewDriver(model);

            if (errors.Count() == 0)
            {
                driverService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age);
                return Redirect("/");
            }

            return View("./Error", errors);
        }
        public async Task<IActionResult> All()
        {
            var drivers = context.Drivers
            .Select(x => new ViewAllDriversViewModel
            {
                DriverId = x.Id,
                Age = x.Age,
                Cup = x.Cup,
                Name = x.Name,
                ImageUrl = x.ImageUrl
            }).ToList();

            return View(drivers);
        }
    }
}
