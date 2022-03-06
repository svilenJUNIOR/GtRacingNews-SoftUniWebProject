using GtRacingNews.Data.DBContext;
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
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewFormModel model)
        {
            if (string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.Heading)) return Redirect("Add");

            var errors = validator.ValidateAddNews(model);

            if (errors.Count() == 0)
            {
                newsService.AddNews(model.Heading, model.Description);
                return Redirect("/");
            }

            return View("./Error", errors);
        }

        public async Task<IActionResult> All()
        {
            var news = context.News
                .Select(x => new ShowAllNewsViewModel
                {
                    Id = x.Id,
                    Heading = x.Heading,
                    ImgUrl = "https://www.linkpicture.com/q/NewsCardImg.jpg"
                }).ToList();

            return View(news);
        }

        public async Task<IActionResult> Details(int id)
        {
            var news = context.News.Where(x => x.Id == id)
                .Select(n => new ReadNewsViewModel
                {
                    NewsId = n.Id,
                    Description = n.Description,
                    Comments = context.Comments.Where(x => x.NewsId == n.Id).Select(x => x.Description).ToList()
                }).FirstOrDefault();

            return View(news);
        }
    }
}
