using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.News;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Newss
{
    public interface INewsService
    {
        Task AddNews(AddNewFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        void EditNews(string Id, AddNewFormModel data);
        ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind);
        ReadNewsViewModel NewsDetails(string newsId);
        ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind);
        ICollection<ShowAllNewsViewModel> GetAll();
    }
}
