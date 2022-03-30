using GtRacingNews.Data.DataModels;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Contracts
{
    public interface IBindService
    {
        ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind);
        ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind);
        ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind);
        ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind);
        ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind);
    }
}
