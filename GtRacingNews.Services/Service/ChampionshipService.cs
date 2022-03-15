using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class ChampionshipService : IChampionshipService
    {

        private readonly GTNewsDbContext context;
        public ChampionshipService(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async Task AddNewChampionship(string name, string logoUrl)
        {
            var championship = new Championship
            {
                Name = name,
                LogoUrl = logoUrl,
            };

            context.Championships.Add(championship);
            await context.SaveChangesAsync();
        }
    }
}
