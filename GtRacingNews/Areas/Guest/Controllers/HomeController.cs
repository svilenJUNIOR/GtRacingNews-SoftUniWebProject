using GtRacingNews.Areas.Guest.ViewModels;
using GtRacingNews.Data.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public IActionResult Index()
        {
            var news = context.News
              .Select(x => new ShowGuestNews
              {
                  Id = x.Id,
                  Heading = x.Heading,
                  Description = x.Description
              }).ToList();

            return View(news);
        }
    }
}
