using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class DeleteController : Controller
    {
        private readonly GTNewsDbContext context;

        public DeleteController(GTNewsDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> DeleteTeam(int Id)
        {
            var team = context.Teams.Where(x => x.Id == Id).FirstOrDefault();

            context.Teams.Remove(team);
            await context.SaveChangesAsync();

            return Redirect("/Team/All");
        }

        public async Task<IActionResult> DeleteChampionship(int Id)
        {
            var Championship = context.Championships.Where(x => x.Id == Id).FirstOrDefault();

            context.Championships.Remove(Championship);
            await context.SaveChangesAsync();

            return Redirect("/Championship/All");
        }

        public async Task<IActionResult> DeleteDriver(int Id)
        {
            var Driver = context.Drivers.Where(x => x.Id == Id).FirstOrDefault();

            context.Drivers.Remove(Driver);
            await context.SaveChangesAsync();

            return Redirect("/Driver/All");
        }

        public async Task<IActionResult> DeleteNews(int Id)
        {
            var News = context.News.Where(x => x.Id == Id).FirstOrDefault();

            context.News.Remove(News);
            await context.SaveChangesAsync();

            return Redirect("/News/All");
        }

        public async Task<IActionResult> DeleteRace(int Id)
        {
            var Race = context.Races.Where(x => x.Id == Id).FirstOrDefault();

            context.Races.Remove(Race);
            await context.SaveChangesAsync();

            return Redirect("/Race/All");
        }

        public async Task<IActionResult> DeleteComment(int Id)
        {
            var Comment = context.Comments.Where(x => x.Id == Id).FirstOrDefault();

            context.Comments.Remove(Comment);
            await context.SaveChangesAsync();

            return Redirect("/News/All");
        }
    }
}
