using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class EditService : IEditService
    {
        private ISqlRepository sqlRepository;

        public EditService(ISqlRepository sqlRepository) 
            => this.sqlRepository = sqlRepository;

        public Team EditTeam(string id)
        {
            var teamToEdit = this.sqlRepository.FindById<Team>(id);
            return teamToEdit;
        }

        public Driver EditDriver(string id)
        {
            var driverToEdit = this.sqlRepository.FindById<Driver>(id);
            return driverToEdit;
        }

        public News EditNews(string id)
        {
            var newsToEdit = this.sqlRepository.FindById<News>(id);
            return newsToEdit;
        }

        public Race EditRace(string id)
        {
            var raceToEdit = this.sqlRepository.FindById<Race>(id);
            return raceToEdit;
        }

        public Championship EditChampionship(string id)
        {
            var championshipToEdit = this.sqlRepository.FindById<Championship>(id);
            return championshipToEdit;
        }
    }
}
