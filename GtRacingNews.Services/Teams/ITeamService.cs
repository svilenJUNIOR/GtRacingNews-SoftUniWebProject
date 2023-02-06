﻿using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Teams
{
    public interface ITeamService
    {
        public Task AddNewTeam(string name, string carModel, string logoUrl, string championshipName, bool isModerator, string userId);
        public void EditTeam(string Id, AddTeamFormModel data);
        public ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind);
        public ViewTeamsAndChampsViewModel TeamsAndChampsBind(ICollection<Team> teamsToBind);
        public AddTeamFormModel BindTeamForEdit(string Id);
        public ICollection<ViewAllTeamsViewModel> GetAll();
    }
}
