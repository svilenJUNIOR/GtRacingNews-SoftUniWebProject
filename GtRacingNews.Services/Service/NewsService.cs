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

        public async Task AddNews(string heading, string description, string pictureUrl)
        {
            var news = new News
            {
                Heading = heading,
                Description = description,
                PictureUrl = pictureUrl
            };

            context.News.Add(news);
            await context.SaveChangesAsync();
        }
    }
}
