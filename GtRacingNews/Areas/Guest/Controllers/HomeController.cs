using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly IEngine engine;
        public HomeController(IEngine engine) => this.engine = engine;
        public IActionResult Index()
        {
            var newsToBind = engine.sqlRepository.GettAll<News>();
            var bindedNews = engine.bindService.GuestNewsBind(newsToBind);

            return View(bindedNews);
        }
    }
}
