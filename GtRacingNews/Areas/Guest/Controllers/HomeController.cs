using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/News/All");
        }
    }
}
