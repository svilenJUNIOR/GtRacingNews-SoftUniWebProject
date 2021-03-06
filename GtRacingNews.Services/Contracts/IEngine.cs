using GtRacingNews.Repository.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public  interface IEngine
    {
        public IAddService addService { get; set; }
        public IBindService bindService { get; set; }
        public IDeleteService deleteService { get; set; }
        public IReturnAll returnAll { get; set; }
        public ISqlSeeder seeder { get; set; }
        public IValidator validator { get; set; }
        public IProfileService profileService { get; set; }
        public ISqlRepository sqlRepository { get; set; }
        public IUserService userService { get; set; }
        public IMongoSeeder mongoSeeder { get; set; }
        public IMongoRepository mongoRepository { get; set; }

        Task<ICollection<Exception>> AddTeam(bool isModerator, string userId, AddTeamFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<Exception>> AddNews(bool isModerator, string userId, AddNewFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<Exception>> AddRace(bool isModerator, string userId, AddNewRaceFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<Exception>> AddDriver(bool isModerator, string userId, AddNewDriverFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<Exception>> AddChampionship(bool isModerator, string userId, AddNewChampionshipFormModel model, string type, ModelStateDictionary modelState);

        ICollection<Exception> CollectErrors(IEnumerable<Exception> dataErrors, IEnumerable<Exception> nullErrors, ModelStateDictionary modelState);
    }
}
