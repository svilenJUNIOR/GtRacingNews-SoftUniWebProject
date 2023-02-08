using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Race;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Races
{
    public interface IRaceService
    {
        Task AddNewRace(AddNewRaceFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        void EditRace(string Id, AddNewRaceFormModel data);
        ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind);
        ICollection<ViewAllRacesViewModel> GetAll();
    }
}
