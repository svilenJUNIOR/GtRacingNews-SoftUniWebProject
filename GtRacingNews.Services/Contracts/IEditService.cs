using GtRacingNews.Data.DataModels.SqlModels;

namespace GtRacingNews.Services.Contracts
{
    public interface IEditService
    {
        Team EditTeam(string id);
        News EditNews(string id);
        Race EditRace(string id);
        Driver EditDriver(string id);
        Championship EditChampionship(string id);
    }
}
