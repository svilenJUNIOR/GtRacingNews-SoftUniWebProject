using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CommentController : Controller
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, int newsId)
        {
            var comment = new Comment
            {
                NewsId = newsId,
                Description = model.Description,
            };

            context.Comments.Add(comment);
            context.SaveChanges();

            return Redirect($"/News/Details?id={newsId}");
        }
    }
}
