using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class TeamService : ITeamService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewTeam(string name)
        {
            var team = new Team
            {
                Name = name,
            };

            context.Teams.Add(team);
            context.SaveChanges();
        }
    }
}
