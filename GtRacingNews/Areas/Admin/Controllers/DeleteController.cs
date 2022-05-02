using GtRacingNews.Areas.Admin.ViewModels;
using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services;
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
        private readonly IDeleteService deleteService;
        private readonly IRepository repository;
        public DeleteController(IDeleteService deleteService, RoleManager<IdentityRole> roleManager,
            IRepository repository)
        {
            this.deleteService = deleteService;
            this.repository = repository;
        }

        public async Task<IActionResult> DeleteView()
        {
            var deleteModel = new DeleteViewModel();

            var Teams = repository.GettAll<Team>();
            var Drivers = repository.GettAll<Driver>();
            var Championships = repository.GettAll<Championship>();
            var News = repository.GettAll<News>();
            var Races = repository.GettAll<Race>();
            var Users = repository.GettAll<IdentityUser>();
            var Roles = repository.GettAll<IdentityRole>();

            foreach (var team in Teams) 
            {
                deleteModel.Teams.Add(team.Name, team.Id);
            }

            foreach (var driver in Drivers)
            {
                deleteModel.Drivers.Add(driver.Name, driver.Id);
            }

            foreach (var championship in Championships)
            {
                deleteModel.Championships.Add(championship.Name, championship.Id);
            }

            foreach (var news in News)
            {
                deleteModel.News.Add(news.Heading, news.Id);
            }

            foreach (var race in Races)
            {
                deleteModel.Races.Add(race.Name, race.Id);
            }

            foreach (var user in Users)
            {
                deleteModel.Users.Add(user.UserName, user.Id);
            }

            foreach (var role in Roles)
            {
                deleteModel.Roles.Add(role.Name, role.Id);
            }

            return View(deleteModel);
        }

        public async Task<IActionResult> Delete(string collection, int Id)
        {
            await deleteService.Delete(collection, Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteComment(int Id, int newsId)
        {
            await deleteService.Delete("Comment", Id);
            return Redirect($"/All/NewsDetails?id={newsId}");
        }
    }
}
