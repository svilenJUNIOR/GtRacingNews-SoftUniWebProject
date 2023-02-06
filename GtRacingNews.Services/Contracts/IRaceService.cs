using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.Race;

namespace GtRacingNews.Services.Contracts
{
    public interface IRaceService
    {
        //add
        public async Task AddNewRace(string name, string date, bool isModerator, string userId)
        {
            var race = new Race(name, date);
            if (isModerator) race.UserId = userId;
            await sqlRepository.AddAsync<Race>((Race)race);
        }
        //edit
        public void EditRace(string Id, AddNewRaceFormModel data)
        {
            var race = this.sqlRepository.FindById<Race>(Id);

            race.Date = data.Date;
            race.Name = data.Name;

            this.sqlRepository.SaveChangesAsync();
        }
        //bind
        public ICollection<ViewAllRacesViewModel> RaceBind(ICollection<Race> racesToBind)
        {
            var bindedRaces = racesToBind.Select(x => new ViewAllRacesViewModel
            {
                Name = x.Name,
                Date = x.Date,
                Id = x.Id,
                HasFinishied = false
            }).ToList();

            for (int i = 0; i < bindedRaces.Count(); i++)
            {
                DateTime date = DateTime.ParseExact(bindedRaces[i].Date, "dd/MM/yyyy", null);
                if (date < DateTime.Now) bindedRaces[i].HasFinishied = true;
            }

            bindedRaces = bindedRaces.OrderBy(x => DateTime.ParseExact(x.Date, "dd/MM/yyyy", null)).ToList();
            return bindedRaces;
        }
        //get
        this.bindService.RaceBind(sqlRepository.GettAll<Race>());
    }
}
