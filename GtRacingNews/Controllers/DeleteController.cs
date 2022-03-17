using GtRacingNews.Data.DBContext;
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
    }
}
