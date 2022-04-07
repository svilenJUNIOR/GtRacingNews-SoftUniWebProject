using GtRacingNews.Data.DataModels;
using GtRacingNews.Services;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRepository repository;
        private readonly IBindService bindService;
        private readonly UserManager<IdentityUser> userManager;
        public ProfileController(IRepository repository, UserManager<IdentityUser> userManager,
            IBindService bindService)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.bindService = bindService;
        }
       
        public async Task<IActionResult> MyProfile()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var userProfile = repository.FindProfileByUserId(currentUser.Id);

            var model = new MyProfileViewModel();

            var teams = this.repository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = bindService.TeamBind(teams);

            var champs = this.repository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = bindService.ChampionshipBind(champs);

            var drivers = this.repository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = bindService.DriverBind(drivers);

            var races = this.repository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = bindService.RaceBind(races);

            var news = this.repository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindNews = bindService.NewsBind(news);

            model.Teams = bindTeams.ToList();
            model.Championships = bindChamps.ToList();
            model.Drivers = bindDrivers.ToList();
            model.News = bindNews.ToList();
            model.Races = bindRaces.ToList();
            model.Age = userProfile.Age;
            model.Email = currentUser.Email;
            model.Address = userProfile.Address;
            model.ProfilePicture = userProfile.ProfilePicture;

            return View(model);
        }
    }
}
