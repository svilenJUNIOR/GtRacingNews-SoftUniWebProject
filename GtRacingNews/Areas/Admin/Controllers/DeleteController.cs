using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeleteController : Controller
    {
        private readonly IEngine engine;
        public DeleteController(IEngine engine) => this.engine = engine;

        public async Task<IActionResult> DeleteView() => View(engine.deleteService.GetItemsForDeletion());

        public async Task<IActionResult> Delete(string collection, string Id)
        {
            await engine.deleteService.Delete(collection, Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteUserOrRole(string collection, string id)
        {
            await engine.deleteService.DeleteUserOrRole(collection, id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteComment(string Id, string newsId)
        {
            await engine.deleteService.Delete("Comment", Id);
            return Redirect($"/All/NewsDetails?id={newsId}");
        }
    }
}
