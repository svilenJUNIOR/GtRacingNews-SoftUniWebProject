using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Teams
{
    public class TeamService : ITeamService
    {
        private ISqlRepository sqlRepository;
        private IGuard guard;
        public TeamService(ISqlRepository sqlRepository, IGuard guard)
        {
            this.sqlRepository = sqlRepository;
            this.guard = guard;
        }

        public async Task AddNewTeam(AddTeamFormModel model, ModelStateDictionary modelState, bool isModerator, string userId)
        {
            ICollection<Exception> Errors = this.guard.CheckModelState(modelState);

            if (Errors.Any()) this.guard.ThrowErrors(Errors);

            var doesExist = this.sqlRepository.GettAll<Team>().Any(x => x.Name == model.Name);
            if (doesExist)
            {
                Errors.Clear();
                Errors.Add(new ArgumentException(Messages.ExistingTeam));
                this.guard.ThrowErrors(Errors);
            }

            var championshipId = this.sqlRepository.GettAll<Championship>().FirstOrDefault(x => x.Name == model.ChampionshipName).Id;
            var team = new Team(model.Name, model.CarModel, model.LogoUrl, championshipId);

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
        public ViewTeamsAndChampsViewModel TeamsAndChampsBind()
        {
            var teamsToBind = this.sqlRepository.GettAll<Team>();
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

            teamsAndChamps.Championships = championships.ToList();
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
        public ICollection<ViewAllTeamsViewModel> GetAll()
            => TeamBind(sqlRepository.GettAll<Team>());
    }
}
