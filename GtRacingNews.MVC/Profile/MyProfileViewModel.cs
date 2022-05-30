using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Delete;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.ViewModels.Profile
{
    public class MyProfileViewModel
    {
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public DeleteFormModel DeleteViewModel { get; set; } = new DeleteFormModel();

        public List<ViewAllTeamsViewModel> Teams = new List<ViewAllTeamsViewModel>();
        public List<ViewAllChampionshipsViewModel> Championships = new List<ViewAllChampionshipsViewModel>();
        public List<ViewAllDriversViewModel> Drivers = new List<ViewAllDriversViewModel>();
        public List<ShowAllNewsViewModel> News = new List<ShowAllNewsViewModel>();
        public List<ViewAllRacesViewModel> Races = new List<ViewAllRacesViewModel>();
    }
}
