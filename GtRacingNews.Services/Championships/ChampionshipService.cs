using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Championships
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly ISqlRepository sqlRepository;
        private IGuard guard;

        public ChampionshipService(ISqlRepository sqlRepository, IGuard guard)
        {
            this.sqlRepository = sqlRepository;
            this.guard = guard;
        }

        public async Task AddNewChampionship(AddNewChampionshipFormModel model, ModelStateDictionary modelState, bool isModerator, string userId)
        {
            ICollection<Exception> Errors = this.guard.CheckModelState(modelState);
            var doesExist = this.sqlRepository.GettAll<Championship>().Any(x => x.Name == model.Name);
            if (doesExist)
            {
                Errors.Add(new ArgumentException(Messages.ExistingChampionship));
                this.guard.ThrowErrors(Errors);
            }

            var championship = new Championship(model.Name, model.LogoUrl);
            if (isModerator) championship.UserId = userId;

            await sqlRepository.AddAsync<Championship>((Championship)championship);
        }

        public void EditChampionship(string Id, AddNewChampionshipFormModel data)
        {
            var champ = this.sqlRepository.FindById<Championship>(Id);

            champ.LogoUrl = data.LogoUrl;
            champ.Name = data.Name;

            this.sqlRepository.SaveChangesAsync();
        }

        public ICollection<ViewAllChampionshipsViewModel> ChampionshipBind(ICollection<Championship> championshipsToBind)
        {
            var teams = sqlRepository.GettAll<Team>();

            var bindedChampionships = championshipsToBind.Select(x => new ViewAllChampionshipsViewModel
            {
                ChampionshipId = x.Id,
                LogoUrl = x.LogoUrl,
                Name = x.Name,
                Teams = teams.Where(t => t.ChampionshipId == x.Id).Select(x => x.Name).ToList()
            }).ToList();

            return bindedChampionships;
        }

        public ICollection<ViewAllChampionshipsViewModel> GetAll()
            => this.ChampionshipBind(sqlRepository.GettAll<Championship>());
    }
}
