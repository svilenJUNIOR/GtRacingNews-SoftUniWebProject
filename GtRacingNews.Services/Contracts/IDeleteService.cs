namespace GtRacingNews.Services.Contracts
{
    public interface IDeleteService
    {
        Task Delete(string collection, int id);
        Task Delete(string id);
    }
}
