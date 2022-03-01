using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewChampionship(string name, string logoUrl)
        {
            var championship = new Championship
            {
                Name = name,
                LogoUrl = logoUrl,
            };

            context.Championships.Add(championship);
            context.SaveChangesAsync();
        }
    }
}
