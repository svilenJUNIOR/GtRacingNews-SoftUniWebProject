namespace GtRacingNews.Services.Contracts
{
    public interface IDeleteService
    {
        Task Delete(string collection, string id);
        Task DeleteUserOrRole(string type, string id);
    }
}
