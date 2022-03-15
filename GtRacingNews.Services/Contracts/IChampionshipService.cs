namespace GtRacingNews.Services.Contracts
{
    public interface IChampionshipService
    {
        Task AddNewChampionship(string name, string logoUrl);
    }
}
