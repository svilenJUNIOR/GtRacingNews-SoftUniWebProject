namespace GtRacingNews.Services.Contracts
{
    public interface IRaceService
    {
        Task AddNewRace(string name, string date);
    }
}
