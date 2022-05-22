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
        private readonly IEngine engine;

        public CommentController(UserManager<IdentityUser> userManager, IEngine engine)
        {
            this.userManager = userManager;
            this.engine = engine;
        }

        [Authorize]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, string newsId)
        {
            var user = await userManager.GetUserAsync(User);

            var nullErrors = engine.validator.AgainstNull(user.UserName, model.Description);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await engine.addService.AddNewComment(model.Description, newsId, user.UserName); return Redirect($"/All/NewsDetails?id={newsId}");
        }
    }
}
