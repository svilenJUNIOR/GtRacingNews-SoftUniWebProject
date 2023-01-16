using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly ISqlRepository sqlRepository;
        private readonly IBindService bindService;
        public HomeController(ISqlRepository sqlRepository, IBindService bindService)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
        }

        public IActionResult Index()
        {
            var newsToBind = sqlRepository.GettAll<News>();
            var bindedNews = bindService.GuestNewsBind(newsToBind);

            return View(bindedNews);
        }
    }
}
