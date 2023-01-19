using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Contracts
{
    public interface IEditService
    {
        void EditTeam(string Id, AddTeamFormModel data);
    }
}
