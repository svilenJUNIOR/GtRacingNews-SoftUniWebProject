using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class TeamController : Controller
    {
        private readonly IReturnAll returnAll;
        public TeamController(IReturnAll returnAll) =>  this.returnAll = returnAll;
        public async Task<IActionResult> All() => View(returnAll.All("Teams"));
    }
}