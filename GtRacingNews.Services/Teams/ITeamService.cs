using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Teams
{
    public interface ITeamService
    {
        Task AddNewTeam(AddTeamFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        void EditTeam(string Id, AddTeamFormModel data);
        ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind);
        ViewTeamsAndChampsViewModel TeamsAndChampsBind(ICollection<Team> teamsToBind);
        AddTeamFormModel BindTeamForEdit(string Id);
        ICollection<ViewAllTeamsViewModel> GetAll();
    }
}
