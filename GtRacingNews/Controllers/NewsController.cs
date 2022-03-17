using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly IValidator validator;
        private readonly INewsService newsService;
        private readonly GTNewsDbContext context;
        private readonly IGuard guard;

        public NewsController(IValidator validator, INewsService newsService, GTNewsDbContext context, IGuard guard)
        {
            this.validator = validator;
            this.newsService = newsService;
            this.context = context;
            this.guard = guard;
        }

        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Heading, model.Description, model.PictureUrl);
            var dataErrors = validator.ValidateAddNews(model);

            if (dataErrors.Count() > 0) return View("./Error", dataErrors);
            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await newsService.AddNews(model.Heading, model.Description, model.PictureUrl); return Redirect("All");
        }

        public async Task<IActionResult> All()
        {
            var news = context.News
                .Select(x => new ShowAllNewsViewModel
                {
                    Id = x.Id,
                    Heading = x.Heading,
                    ImgUrl = x.PictureUrl
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
                    Comments = context.Comments.Where(x => x.NewsId == n.Id).ToList()
                }).FirstOrDefault();

            return View(news);
        }
    }
}
