using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly IReturnAll returnAll;
        public NewsController(IReturnAll returnAll) => this.returnAll = returnAll;
        public async Task<IActionResult> All() => View(returnAll.All("News"));
        public async Task<IActionResult> Details(int Id) => View(returnAll.NewsDeatils(Id));
    }
}
