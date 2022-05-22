using GtRacingNews.Data.DataModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ISqlRepoisitory sqlRepository;
        private readonly IBindService bindService;
        private readonly IDeleteService deleteService;
        private readonly UserManager<IdentityUser> userManager;
        public ProfileController(ISqlRepoisitory sqlRepository, UserManager<IdentityUser> userManager,
            IBindService bindService, IDeleteService deleteService)
        {
            this.sqlRepository = sqlRepository;
            this.userManager = userManager;
            this.bindService = bindService;
            this.deleteService = deleteService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var userProfile = sqlRepository.FindProfileByUserId(currentUser.Id);

            var model = new MyProfileViewModel();

            var teams = this.sqlRepository.GettAll<Team>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindTeams = bindService.TeamBind(teams);

            var champs = this.sqlRepository.GettAll<Championship>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindChamps = bindService.ChampionshipBind(champs);

            var drivers = this.sqlRepository.GettAll<Driver>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindDrivers = bindService.DriverBind(drivers);

            var races = this.sqlRepository.GettAll<Race>().Where(x => x.UserId == currentUser.Id).ToList();
            var bindRaces = bindService.RaceBind(races);

            var news = this.sqlRepository.GettAll<News>().Where(x => x.UserId == currentUser.Id).ToList();
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

        public async Task<IActionResult> Delete(string collection, string Id)
        {
            await deleteService.Delete(collection, Id);
            return Redirect("MyProfile");
        }
    }
}
