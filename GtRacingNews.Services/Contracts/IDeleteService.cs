using GtRacingNews.ViewModels.Delete;

namespace GtRacingNews.Services.Contracts
{
    public interface IDeleteService
    {
        Task Delete(string collection, string id);
        Task DeleteUserOrRole(string type, string id);
        DeleteFormModel GetItemsForDeletion();
    }
}
