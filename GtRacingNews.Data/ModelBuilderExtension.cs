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
        }
    }
}
