using GtRacingNews.Areas.Admin.ViewModels;
using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeleteController : Controller
    {
        private readonly IEngine engine;
        public DeleteController(IEngine engine) => this.engine = engine;

        public async Task<IActionResult> DeleteView()
        {
            var deleteModel = new DeleteFormModel();

            var Teams = this.engine.sqlRepository.GettAll<Team>();
            var Drivers = this.engine.sqlRepository.GettAll<Driver>();
            var Championships = this.engine.sqlRepository.GettAll<Championship>();
            var News = this.engine.sqlRepository.GettAll<News>();
            var Races = this.engine.sqlRepository.GettAll<Race>();
            var Users = this.engine.sqlRepository.GettAll<IdentityUser>();
            var Roles = this.engine.sqlRepository.GettAll<IdentityRole>();

            foreach (var team in Teams)
                deleteModel.Teams.Add(team.Name, team.Id);

            foreach (var driver in Drivers)
                deleteModel.Drivers.Add(driver.Name, driver.Id);

            foreach (var championship in Championships)
                deleteModel.Championships.Add(championship.Name, championship.Id);

            foreach (var news in News)
                deleteModel.News.Add(news.Heading, news.Id);

            foreach (var race in Races)
                deleteModel.Races.Add(race.Name, race.Id);

            foreach (var user in Users)
                deleteModel.Users.Add(user.UserName, user.Id);

            foreach (var role in Roles)
                deleteModel.Roles.Add(role.Name, role.Id);

            return View(deleteModel);
        }

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
