using GtRacingNews.ViewModels.Race;

namespace GtRacingNews.Services.Race
{
    public interface IRaceService
    {
        public Task AddNewRace(string name, string date, bool isModerator, string userId);
        public void EditRace(string Id, AddNewRaceFormModel data);
        public ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind);
    }
}
