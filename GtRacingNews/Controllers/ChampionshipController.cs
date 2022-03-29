using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly IReturnAll returnAll;
        public ChampionshipController(IReturnAll returnAll) => this.returnAll = returnAll;
        public async Task<IActionResult> All() => View(returnAll.All("Championships"));
    }
}
