using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeleteController : Controller
    {
        private IDeleteService deleteService;
        public DeleteController(IDeleteService deleteService) => this.deleteService = deleteService;

        public async Task<IActionResult> DeleteView() => View(deleteService.GetItemsForDeletion());

        public async Task<IActionResult> Delete(string collection, string Id)
        {
            await deleteService.Delete(collection, Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteUserOrRole(string collection, string id)
        {
            await deleteService.DeleteUserOrRole(collection, id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteComment(string Id, string newsId)
        {
            await deleteService.Delete("Comment", Id);
            return Redirect($"/All/NewsDetails?id={newsId}");
        }
    }
}
