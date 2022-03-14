using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class NewsService : INewsService
    {
        private readonly GTNewsDbContext context;
        public NewsService(GTNewsDbContext context)
        {
            this.context = context;
        }

        public async void AddNews(string heading, string description)
        {
            var news = new News
            {
                Heading = heading,
                Description = description
            };

            context.News.Add(news);
            await context.SaveChangesAsync();
        }
    }
}
