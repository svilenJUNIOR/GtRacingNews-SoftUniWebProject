using GtRacingNews.Data.DataModels;

using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        //private readonly IBindService bindService;
        //private readonly IRepository repository;
        //public HomeController(IBindService bindService, IRepository repository) 
        //{
        //    this.bindService = bindService;
        //    this.repository = repository;
        //} 
        //public IActionResult Index()
        //{
        //    var newsToBind = repository.GettAll<News>();
        //    var bindedNews = bindService.GuestNewsBind(newsToBind);

        //    return View(bindedNews);
        //}
    }
}
