using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Contracts
{
    public interface IBindService
    {
        ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind);
        ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind);
        ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind);
        ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind);
        ViewTeamsAndChampsViewModel TeamsAndChampsBind(ICollection<Team> teamsAndChampsToBind);
        ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind);
        ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind);
        MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile);
        AddTeamFormModel BindTeamForEdit(string Id);
        AddNewDriverFormModel BindDriverForEdit(string Id);
    }
}
