using GtRacingNews.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GtRacingNews.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Heading = "Nissan Won Le Mans",
                    Description = "Finally some good news, for the Nismo motorsport team fans!"
                }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, NewsId = 1, Description = "I was starting to loose hope." },
                new Comment { Id = 2, NewsId = 1, Description = "Go go NISMO." },
                new Comment { Id = 3, NewsId = 1, Description = "I told you Alex Buncombe is a fast pilot!!!" }
            );
        }
    }
}
