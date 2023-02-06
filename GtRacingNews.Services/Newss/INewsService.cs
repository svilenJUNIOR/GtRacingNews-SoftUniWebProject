using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Newss
{
    public interface INewsService
    {
        public Task AddNews(string heading, string description, string pictureUrl, bool isModerator, string userId);
        public void EditNews(string Id, AddNewFormModel data);
        public ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind);
        public ReadNewsViewModel NewsDetails(string newsId);
        public ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind);
        public ICollection<ShowAllNewsViewModel> GetAll();
    }
}
