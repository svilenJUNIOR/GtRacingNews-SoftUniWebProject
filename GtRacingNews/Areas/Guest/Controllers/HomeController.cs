using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Newss;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly ISqlRepository sqlRepository;
        private INewsService newsService;
        public HomeController(INewsService newsService)
        {
            this.sqlRepository = sqlRepository;
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            var newsToBind = sqlRepository.GettAll<News>();
            var bindedNews = newsService.GuestNewsBind(newsToBind);

            return View(bindedNews);
        }
    }
}
