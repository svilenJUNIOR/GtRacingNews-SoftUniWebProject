using GtRacingNews.Areas.Admin.ViewModels;
using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeleteController : Controller
    {
        private readonly IDeleteService deleteService;
        private readonly GTNewsDbContext context;
        public DeleteController(IDeleteService deleteService, GTNewsDbContext context)
        {
            this.deleteService = deleteService;
            this.context = context;
        }

        public async Task<IActionResult> DeleteView()
        {
            var deleteModel = new DeleteViewModel();

            var Teams = context.Teams.ToList();
            var Drivers = context.Drivers.ToList();
            var Championships = context.Championships.ToList();
            var News = context.News.ToList();
            var Races = context.Races.ToList();
            var Users = context.Users.ToList();

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

            return View(deleteModel);
        }

        public async Task<IActionResult> DeleteTeam(int Id)
        {
            await deleteService.Delete("Team", Id); 
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteChampionship(int Id)
        {
            await deleteService.Delete("Championship", Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteDriver(int Id)
        {
            await deleteService.Delete("Driver", Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteNews(int Id)
        {
            await deleteService.Delete("News", Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteRace(int Id)
        {
            await deleteService.Delete("Race", Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteComment(int Id)
        {
            await deleteService.Delete("Comment", Id);
            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteUser(string Id)
        {
            await deleteService.Delete(Id);
            return Redirect("DeleteView");
        }
    }
}
