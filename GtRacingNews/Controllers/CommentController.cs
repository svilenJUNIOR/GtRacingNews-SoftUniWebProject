using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IGuard guard;
        private readonly IAddService addService;
        public CommentController(UserManager<IdentityUser> userManager, IGuard guard, IAddService addService)
        {
            this.userManager = userManager;
            this.guard = guard;
            this.addService = addService;
        }

        [Authorize]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, int newsId)
        {
            Type type = typeof(Comment);

            var user = await userManager.GetUserAsync(User);

            var nullErrors = guard.AgainstNull(user.UserName, model.Description);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await addService.AddNewComment(type, model.Description, newsId, user.UserName); return Redirect($"/News/Details?id={newsId}");
        }
    }
}
