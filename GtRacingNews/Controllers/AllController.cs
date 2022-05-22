using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    [Authorize]
    public class AllController : Controller
    {
        private readonly IEngine engine;
        public AllController(IEngine engine) => this.engine = engine;

        public async Task<IActionResult> AllChampionships() => View(engine.returnAll.All("Championships"));
        public async Task<IActionResult> AllDrivers() => View(engine.returnAll.All("Drivers"));
        public async Task<IActionResult> AllNews() => View(engine.returnAll.All("News"));
        public async Task<IActionResult> NewsDetails(string Id) => View(engine.returnAll.NewsDeatils(Id));
        public async Task<IActionResult> AllRaces() => View(engine.returnAll.All("Races"));
        public async Task<IActionResult> AllTeams() => View(engine.returnAll.All("Teams"));
    }
}
