using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.Championship;

namespace GtRacingNews.Services.Contracts
{
    public interface IChampionshipService
    {
        //add
        public async Task AddNewChampionship(string name, string logoUrl, bool isModerator, string userId)
        {
            var championship = new Championship(name, logoUrl);
            if (isModerator) championship.UserId = userId;
            await sqlRepository.AddAsync<Championship>((Championship)championship);
        }
        //edit
        public void EditChampionship(string Id, AddNewChampionshipFormModel data)
        {
            var champ = this.sqlRepository.FindById<Championship>(Id);

            champ.LogoUrl = data.LogoUrl;
            champ.Name = data.Name;

            this.sqlRepository.SaveChangesAsync();
        }
        //bind
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
        //get
        this.bindService.ChampionshipBind(sqlRepository.GettAll<Championship>());

    }
}
