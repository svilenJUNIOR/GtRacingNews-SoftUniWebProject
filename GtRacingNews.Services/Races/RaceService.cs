using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.ViewModels.Race;

namespace GtRacingNews.Services.Races
{
    public class RaceService : IRaceService
    {
        private ISqlRepository sqlRepository;
        public RaceService(ISqlRepository sqlRepository)
            => this.sqlRepository = sqlRepository;

        public async Task AddNewRace(string name, string date, bool isModerator, string userId)
        {
            var race = new Race(name, date);
            if (isModerator) race.UserId = userId;
            await sqlRepository.AddAsync<Race>((Race)race);
        }
       
        public void EditRace(string Id, AddNewRaceFormModel data)
        {
            var race = this.sqlRepository.FindById<Race>(Id);

            race.Date = data.Date;
            race.Name = data.Name;

            this.sqlRepository.SaveChangesAsync();
        }
       
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
        
        public ICollection<ViewAllRacesViewModel> GetAll()
         => this.RaceBind(sqlRepository.GettAll<Race>());
    }
}
