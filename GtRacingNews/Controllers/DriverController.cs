using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class DriverController : Controller
    {
        private readonly IReturnAll returnAll;
        public DriverController(IReturnAll returnAll) => this.returnAll = returnAll;
        public async Task<IActionResult> All() => View(returnAll.All("Drivers"));
    }
}
