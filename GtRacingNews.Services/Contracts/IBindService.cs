﻿using GtRacingNews.Data.DataModels.SqlModels;
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
        ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind);
        ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind);

        ReadNewsViewModel NewsDetails(string newsId);
        MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile);
        ViewTeamsAndChampsViewModel TeamsAndChampsBind(ICollection<Team> teamsAndChampsToBind);
        AddTeamFormModel BindTeamForEdit(string Id);
        AddNewDriverFormModel BindDriverForEdit(string Id);
    }
}
