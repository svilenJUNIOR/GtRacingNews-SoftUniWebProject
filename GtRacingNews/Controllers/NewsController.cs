using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.News;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly INewsService newsService = new NewsService();

        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewFormModel model)
        {
            var errors = validator.ValidateAddNews(model);

            if (errors.Count() == 0)
            {
                newsService.AddNews(model.Heading, model.Description);
                return Redirect("/");
            }

            return View("./Error", errors);
        }
    }
}
