using GtRacingNews.Data.DataModels;

namespace GtRacingNews.Services.Contracts
{
    public interface IDriverService
    {
        void AddNewDriver(string name, string cup, string imageUrl, int age, string teamName);
    }
}
