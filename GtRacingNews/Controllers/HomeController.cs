using GtRacingNews.Data.DBContext;
using GtRacingNews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GtRacingNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GTNewsDbContext context;
        public HomeController(ILogger<HomeController> logger, GTNewsDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var latesNews = context.News.OrderBy(x => x.Id).LastOrDefault();
            latesNews.Description = latesNews.Description.Split(".")[0];
            return View(latesNews);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}