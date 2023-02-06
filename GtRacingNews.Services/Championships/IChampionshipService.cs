using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Championship;

namespace GtRacingNews.Services.Championships
{
    public interface IChampionshipService
    {
        public Task AddNewChampionship(string name, string logoUrl, bool isModerator, string userId);
        public void EditChampionship(string Id, AddNewChampionshipFormModel data);
        public ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind);
        public ICollection<ViewAllChampionshipsViewModel> GetAll();

    }
}
