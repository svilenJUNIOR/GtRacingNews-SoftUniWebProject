using GtRacingNews.Data.DataModels;
using GtRacingNews.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRepository repository;
        private readonly UserManager<IdentityUser> userManager;
        public ProfileController(IRepository repository, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
       
        public async Task<IActionResult> MyTeams()
        {
            var currentUserId = this.userManager.FindByNameAsync(this.User.Identity.Name).Id;
            var teams = this.repository.GettAll<Team>();
            return View();
        }
    }
}
