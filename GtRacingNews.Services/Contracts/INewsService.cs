using GtRacingNews.Data.DataModels;

namespace GtRacingNews.Services.Contracts
{
    public interface INewsService
    {
        Task AddNews(string heading, string description, string pictureUrl);
    }
}
