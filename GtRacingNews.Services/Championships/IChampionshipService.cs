using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Championships
{
    public interface IChampionshipService
    {
        public Task AddNewChampionship(AddNewChampionshipFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        public void EditChampionship(string Id, AddNewChampionshipFormModel data);
        public ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind);
        public ICollection<ViewAllChampionshipsViewModel> GetAll();

    }
}
