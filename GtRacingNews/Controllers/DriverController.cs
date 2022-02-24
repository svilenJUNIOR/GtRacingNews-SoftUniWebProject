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
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewDriverFormModel model)
        {
            var errors = validator.ValidateAddNewDriver(model);

            if (errors.Count() == 0)
            {
                driverService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age);
                return Redirect("/");
            }

            return View("./Error", errors);
        }
    }
}
