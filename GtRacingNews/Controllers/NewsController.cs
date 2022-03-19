using GtRacingNews.Data.DBContext;
using GtRacingNews.ViewModels.News;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly GTNewsDbContext context;

        public NewsController(GTNewsDbContext context)
        {
            this.context = context;
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
