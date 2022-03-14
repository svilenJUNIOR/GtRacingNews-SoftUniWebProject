using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICommentService commentService = new CommentService();
        public CommentController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, int newsId)
        {
            var user = await userManager.GetUserAsync(User);

            commentService.AddNewComment(model.Description, newsId, user.UserName);

            return Redirect($"/News/Details?id={newsId}");
        }
    }
}
