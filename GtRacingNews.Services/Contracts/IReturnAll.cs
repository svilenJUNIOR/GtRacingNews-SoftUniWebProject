using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Contracts
{
    public interface IReturnAll
    {
        public IEnumerable<object> All(string Entity);
        public ReadNewsViewModel NewsDeatils(string newsId);
    }
}
