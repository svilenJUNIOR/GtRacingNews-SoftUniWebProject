using GtRacingNews.Services.Comments;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CommentController : Controller
    {
        private IGuard guard;
        private ICommentService commentService;

        private readonly UserManager<IdentityUser> userManager;

        public CommentController(IGuard guard, ICommentService commentService, UserManager<IdentityUser> userManager)
        {
            this.guard = guard;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, string newsId)
        {
            var user = await userManager.GetUserAsync(User);

            try
            {
                await commentService.AddNewComment(model, ModelState, newsId, user.UserName);
                return Redirect("/");
            }

            catch (AggregateException exception)
            {
                HashSet<string> errors = new HashSet<string>();

                foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

                return Redirect($"/All/NewsDetails?id={newsId}");
            }
        }
    }
}
