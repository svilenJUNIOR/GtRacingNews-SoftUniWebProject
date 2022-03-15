using GtRacingNews.Data.DataModels;

namespace GtRacingNews.Services.Contracts
{
    public interface INewsService
    {
        void AddNews(string heading, string description, string pictureUrl);
    }
}
