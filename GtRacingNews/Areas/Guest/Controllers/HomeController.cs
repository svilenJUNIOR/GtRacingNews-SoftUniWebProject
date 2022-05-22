using GtRacingNews.Data.DataModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly IBindService bindService;
        private readonly ISqlRepoisitory sqlRepository;
        public HomeController(IBindService bindService, ISqlRepoisitory sqlRepository)
        {
            this.bindService = bindService;
            this.sqlRepository = sqlRepository;
        }
        public IActionResult Index()
        {
            var newsToBind = sqlRepository.GettAll<News>();
            var bindedNews = bindService.GuestNewsBind(newsToBind);

            return View(bindedNews);
        }
    }
}
