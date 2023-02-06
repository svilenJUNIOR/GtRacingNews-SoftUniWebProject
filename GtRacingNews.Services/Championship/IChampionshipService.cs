using GtRacingNews.ViewModels.Championship;

namespace GtRacingNews.Services.Championship
{
    public interface IChampionshipService
    {
        public Task AddNewChampionship(string name, string logoUrl, bool isModerator, string userId);
        public void EditChampionship(string Id, AddNewChampionshipFormModel data);
        public ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind);
        public ICollection<Championship> GetAll();

    }
}
