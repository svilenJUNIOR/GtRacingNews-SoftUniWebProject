using GtRacingNews.Data.DataModels;

namespace GtRacingNews.Services.Contracts
{
    public interface IDriverService
    {
        Task AddNewDriver(string name, string cup, string imageUrl, int age, string teamName);
    }
}
