using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Race;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Races
{
    public interface IRaceService
    {
        public Task AddNewRace(AddNewRaceFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        public void EditRace(string Id, AddNewRaceFormModel data);
        public ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind);
        public ICollection<ViewAllRacesViewModel> GetAll();
    }
}
