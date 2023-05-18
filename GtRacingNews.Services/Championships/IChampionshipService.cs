using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Championships
{
    public interface IChampionshipService
    {
       Task AddNewChampionship(AddNewChampionshipFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
       void EditChampionship(string Id, AddNewChampionshipFormModel data);
       List<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind);
        List<ViewAllChampionshipsViewModel> GetAll();
    }
}
