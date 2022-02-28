using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewChampionship(string name)
        {
            var championship = new Championship
            {
                Name = name,
            };

            context.Championships.Add(championship);
            context.SaveChangesAsync();
        }
    }
}
