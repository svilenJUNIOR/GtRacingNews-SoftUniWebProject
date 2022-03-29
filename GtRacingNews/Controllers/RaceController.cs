using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class RaceController : Controller
    {
        private readonly IReturnAll returnAll;
        public RaceController(IReturnAll returnAll) => this.returnAll = returnAll;
        public async Task<IActionResult> All() => View(returnAll.All("Races"));
    }
}
