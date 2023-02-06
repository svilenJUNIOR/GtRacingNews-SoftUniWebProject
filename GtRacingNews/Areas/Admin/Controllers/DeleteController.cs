using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Services.Others.Contracts;
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

        public async Task<IActionResult> DeleteTeam(string Id)
        {
            await deleteService.Delete<Team>(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteChampionship(string Id)
        {
            await deleteService.Delete<Championship>(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteDriver(string Id)
        {
            await deleteService.Delete<Driver>(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteNews(string Id)
        {
            await deleteService.Delete<News>(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteComment(string Id)
        {
            await deleteService.Delete<Comment>(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteRace(string Id)
        {
            await deleteService.Delete<Race>(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteUser(string Id)
        {
            await deleteService.DeleteUser(Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteRole(string Id)
        {
            await deleteService.DeleteRole(Id);
            return Redirect("DeleteView");
        }
    }
}
