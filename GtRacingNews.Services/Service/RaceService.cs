using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class RaceService : IRaceService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewRace(string name, string date)
        {
            var race = new Race
            {
                Name = name,
                Date = date
            };

            context.Races.Add(race);
            context.SaveChanges();
        }
    }
}
