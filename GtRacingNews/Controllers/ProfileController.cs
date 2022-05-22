using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEngine engine;
        public ProfileController(IEngine engine, UserManager<IdentityUser> userManager)
        {
            this.engine = engine;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyProfile()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var userProfile = engine.sqlRepository.FindProfileByUserId(currentUser.Id);

            var model = new MyProfileViewModel();

            var teams = this.engine.sqlRepository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = engine.bindService.TeamBind(teams);

            var champs = this.engine.sqlRepository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = engine.bindService.ChampionshipBind(champs);

            var drivers = this.engine.sqlRepository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = engine.bindService.DriverBind(drivers);

            var races = this.engine.sqlRepository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = engine.bindService.RaceBind(races);

            var news = this.engine.sqlRepository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindNews = engine.bindService.NewsBind(news);

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

        public async Task<IActionResult> Delete(string collection, string Id)
        {
            await engine.deleteService.Delete(collection, Id);
            return Redirect("MyProfile");
        }
    }
}
