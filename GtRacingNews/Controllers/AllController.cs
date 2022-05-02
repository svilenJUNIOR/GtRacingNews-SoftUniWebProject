using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace GtRacingNews.Controllers
{
    [Authorize]
    public class AllController : Controller
    {
        private readonly IReturnAll returnAll;
        public AllController(IReturnAll returnAll) => this.returnAll = returnAll;
        public async Task<IActionResult> AllChampionships() => View(returnAll.All("Championships"));
        public async Task<IActionResult> AllDrivers() => View(returnAll.All("Drivers"));
        public async Task<IActionResult> AllNews() => View(returnAll.All("News"));
        public async Task<IActionResult> NewsDetails(int Id) => View(returnAll.NewsDeatils(Id));
        public async Task<IActionResult> AllRaces() => View(returnAll.All("Races"));
        public async Task<IActionResult> AllTeams() => View(returnAll.All("Teams"));
    }
}
