using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Contracts
{
    public interface IEditService
    {
        void EditTeam(string Id, AddTeamFormModel data);
        void EditChampionship(string Id, AddNewChampionshipFormModel data);
        void EditDriver(string Id, AddNewDriverFormModel data);
        void EditRace(string Id, AddNewRaceFormModel data);
        void EditNews(string Id, AddNewFormModel data);
    }
}
