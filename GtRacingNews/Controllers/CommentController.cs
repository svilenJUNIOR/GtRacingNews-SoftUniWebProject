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
        private readonly IAddService addService;
        private readonly IValidator validator;
        public CommentController(UserManager<IdentityUser> userManager,IAddService addService, IValidator validator)
        {
            this.userManager = userManager;
            this.addService = addService;
            this.validator = validator;
        }

        [Authorize]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewCommentFormModel model, int newsId)
        {
            var user = await userManager.GetUserAsync(User);

            var nullErrors = validator.AgainstNull(user.UserName, model.Description);

            if (nullErrors.Count() > 0) return View("./Error", nullErrors);

            else await addService.AddNewComment(model.Description, newsId, user.UserName); return Redirect($"/All/NewsDetails?id={newsId}");
        }
    }
}
