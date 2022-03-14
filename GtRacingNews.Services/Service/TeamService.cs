using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class TeamService : ITeamService
    {
        private readonly GTNewsDbContext context;
        public TeamService(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async void AddNewTeam(string name, string carModel, string logoUrl, string championshipName)
        {
            var championship = context.Championships.Where(x => x.Name == championshipName).FirstOrDefault();
            
            var team = new Team
            {
                Name = name,
                CarModel = carModel,
                LogoUrl = logoUrl,
                ChampionshipId = championship.Id,
            };

            context.Teams.Add(team);
            await context.SaveChangesAsync();
        }
    }
}
