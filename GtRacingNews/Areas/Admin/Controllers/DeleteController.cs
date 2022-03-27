using GtRacingNews.Areas.Admin.ViewModels;
using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeleteController : Controller
    {
        private readonly GTNewsDbContext context;

        public DeleteController(GTNewsDbContext context)
        {
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
            var team = context.Teams.Where(x => x.Id == Id).FirstOrDefault();


            var repo = new Repository<Team>();

            await repo.Remove(team);

            return Redirect("/");
        }

        public async Task<IActionResult> DeleteChampionship(int Id)
        {
            var Championship = context.Championships.Where(x => x.Id == Id).FirstOrDefault();

            context.Championships.Remove(Championship);
            await context.SaveChangesAsync();

            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteDriver(int Id)
        {
            var Driver = context.Drivers.Where(x => x.Id == Id).FirstOrDefault();

            context.Drivers.Remove(Driver);
            await context.SaveChangesAsync();

            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteNews(int Id)
        {
            var News = context.News.Where(x => x.Id == Id).FirstOrDefault();

            context.News.Remove(News);
            await context.SaveChangesAsync();

            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteRace(int Id)
        {
            var Race = context.Races.Where(x => x.Id == Id).FirstOrDefault();

            context.Races.Remove(Race);
            await context.SaveChangesAsync();

            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteComment(int Id)
        {
            var Comment = context.Comments.Where(x => x.Id == Id).FirstOrDefault();

            context.Comments.Remove(Comment);
            await context.SaveChangesAsync();

            return Redirect("DeleteView");
        }

        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return Redirect("DeleteView");
        }
    }
}
