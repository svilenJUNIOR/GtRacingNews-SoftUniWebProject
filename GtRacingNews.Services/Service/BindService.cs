using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Service
{
    public class BindService : IBindService
    {
        public ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind)
        {
            var bindedNews = newsToBind.Select(x => new ShowAllNewsViewModel
            {
                Heading = x.Heading,
                Id = x.Id,
                ImgUrl = x.PictureUrl
            });

            return bindedNews.ToList();
        }
    }
}
