using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Team
{
    public class TeamService : ITeamService
    {
        public async Task AddNewTeam(string name, string carModel, string logoUrl, string championshipName, bool isModerator, string userId)
        {
            var championshipId = sqlRepository.GettAll<Championship>().FirstOrDefault(x => x.Name == championshipName).Id;
            var team = new Team(name, carModel, logoUrl, championshipId);

            if (isModerator) team.UserId = userId;

            await sqlRepository.AddAsync<Team>((Team)team);
        }
        public void EditTeam(string Id, AddTeamFormModel data)
        {
            var team = this.sqlRepository.FindById<Team>(Id);

            team.Name = data.Name;
            team.LogoUrl = data.LogoUrl;
            team.CarModel = data.CarModel;
            team.ChampionshipId = this.sqlRepository.GettAll<Championship>().
                FirstOrDefault(x => x.Name == data.ChampionshipName).Id;

            this.sqlRepository.SaveChangesAsync();
        }
        public ICollection<ViewAllTeamsViewModel> TeamBind(ICollection<Team> teamsToBind)
        {
            var drivers = sqlRepository.GettAll<Driver>();

            var bindedTeams = teamsToBind.Select(x => new ViewAllTeamsViewModel
            {
                Name = x.Name,
                CarModel = x.CarModel,
                ChampionshipName = this.sqlRepository.FindById<Championship>(x.ChampionshipId).Name,
                Drivers = drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList(),
                Id = x.Id,
                LogoUrl = x.LogoUrl,
            }).ToList();

            return bindedTeams;
        }
        public ViewTeamsAndChampsViewModel TeamsAndChampsBind(ICollection<Team> teamsToBind)
        {
            var drivers = sqlRepository.GettAll<Driver>();
            var championships = sqlRepository.GettAll<Championship>();

            var bindedTeams = teamsToBind.Select(x => new ViewAllTeamsViewModel
            {
                Name = x.Name,
                CarModel = x.CarModel,
                ChampionshipName = this.sqlRepository.FindById<Championship>(x.ChampionshipId).Name,
                Drivers = drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList(),
                Id = x.Id,
                LogoUrl = x.LogoUrl,
            }).ToList();

            ViewTeamsAndChampsViewModel teamsAndChamps = new ViewTeamsAndChampsViewModel();

            teamsAndChamps.Championships = championships;
            teamsAndChamps.Teams = bindedTeams;

            return teamsAndChamps;
        }
        public AddTeamFormModel BindTeamForEdit(string Id)
        {
            var team = this.sqlRepository.GettAll<Team>().FirstOrDefault(x => x.Id == Id);

            AddTeamFormModel objToEdit = new AddTeamFormModel()
            {
                CarModel = team.CarModel,
                ChampionshipName = this.sqlRepository.GettAll<Championship>().FirstOrDefault(x => x.Id == team.ChampionshipId).Name,
                Championships = this.sqlRepository.GettAll<Championship>(),
                LogoUrl = team.LogoUrl,
                Name = team.Name,
            };

            return objToEdit;
        }

        public ICollection<Team> GetTeamsAndChamps()
        {
            TeamsAndChampsBind(sqlRepository.GettAll<Team>());
        }
    }
}
