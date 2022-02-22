using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterUserFormModel model)
        {
            return View(model);
        }

    }
}
