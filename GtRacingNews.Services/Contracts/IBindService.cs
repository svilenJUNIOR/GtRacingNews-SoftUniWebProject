using GtRacingNews.Data.DataModels;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Contracts
{
    public interface IBindService
    {
        ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind);
    }
}
