using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GtRacingNews.Controllers
{
    public class DriverController : Controller
    {
        private readonly IValidator validator;
        private readonly IDriverService driverService;
        private readonly GTNewsDbContext context;
        private readonly IGuard guard;

        public DriverController(IValidator validator, IDriverService driverService, GTNewsDbContext context, IGuard guard)
        {
            this.validator = validator;
            this.driverService = driverService;
            this.context = context;
            this.guard = guard;
        }

        public async Task<IActionResult> Add()
        {
            var teams = context.Teams.Where(x => x.Drivers.Count() < 3).ToList();
            AddNewDriverFormModel model = new AddNewDriverFormModel();
            model.Teams = teams;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewDriverFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.TeamName, model.Age.ToString(), model.ImageUrl, model.Cup);
            var dataErrors = validator.ValidateAddNewDriver(model);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);
            if (dataErrors.Count() > 0) return View("./Error", dataErrors);

            else driverService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age, model.TeamName); return Redirect("/");
        }

        public async Task<IActionResult> All()
        {
            var driversTemp = context.Drivers.ToList();

            var drivers = context.Drivers
            .Select(x => new ViewAllDriversViewModel
            {
                DriverId = x.Id,
                Age = x.Age,
                Cup = x.Cup,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
            }).ToList();


            return View(drivers);
        }
    }
}
