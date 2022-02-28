using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class NewsService : INewsService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();

        public void AddNews(string heading, string description)
        {
            var news = new News
            {
                Heading = heading,
                Description = description
            };

            context.News.Add(news);
            context.SaveChangesAsync();
        }
    }
}
