using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class CommentController : Controller
    {
        private IGuard guard;
        private IAddService addService;

        private readonly UserManager<IdentityUser> userManager;

        public CommentController(IGuard guard, IAddService addService, UserManager<IdentityUser> userManager)
        {
            this.guard = guard;
            this.addService = addService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, string newsId)
        {
            var user = await userManager.GetUserAsync(User);
            var nullErrors = guard.AgainstNull(user.UserName, model.Description);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await addService.AddNewComment(model.Description, newsId, user.UserName); return Redirect($"/All/NewsDetails?id={newsId}");
        }
    }
}
