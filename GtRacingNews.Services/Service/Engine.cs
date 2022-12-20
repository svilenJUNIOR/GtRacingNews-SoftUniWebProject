using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Engine : IEngine
    {
        public IAddService addService { get; set; }
        public IBindService bindService { get; set; }
        public IDeleteService deleteService { get; set; }
        public IReturnAll returnAll { get; set; }
        public ISqlSeeder seeder { get; set; }
        public IGuard guard { get; set; }
        public IValidator validator { get; set; }
        public ISqlRepository sqlRepository { get; set; }
        public IUserService userService { get; set; }

        public Engine
            (
                IAddService addService,
                IBindService bindService,
                IDeleteService deleteService,
                IReturnAll returnAll,
                ISqlSeeder seeder,
                IValidator validator,
                ISqlRepository sqlRepository,
                IUserService userService,
                IGuard guard
            )
        {
            this.addService = addService;
            this.bindService = bindService;
            this.deleteService = deleteService;
            this.returnAll = returnAll;
            this.seeder = seeder;
            this.validator = validator;
            this.sqlRepository = sqlRepository;
            this.userService = userService;
            this.guard = guard;
        }

        public async Task<ICollection<Exception>> AddTeam(bool isModerator, string userId, AddTeamFormModel model, string type, ModelStateDictionary modelState)
        {
            ICollection<Exception> errors = this.validator.ValidateTeam(model, type, modelState);

            if (errors.Count() == 0) await addService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName, isModerator, userId);

            return errors;
        }
        public async Task<ICollection<Exception>> AddNews(bool isModerator, string userId, AddNewFormModel model, string type, ModelStateDictionary modelState)
        {
            ICollection<Exception> errors = this.validator.ValidateNews(model, modelState);

            if (errors.Count() == 0) await addService.AddNews(model.Heading, model.Description, model.PictureUrl, isModerator, userId);

            return errors;
        }
        public async Task<ICollection<Exception>> AddRace(bool isModerator, string userId, AddNewRaceFormModel model, string type, ModelStateDictionary modelState)
        {
            ICollection<Exception> errors = this.validator.ValidateRace(model, modelState);

            if (errors.Count() == 0) await addService.AddNewRace(model.Name, model.Date, isModerator, userId);

            return errors;
        }
        public async Task<ICollection<Exception>> AddDriver(bool isModerator, string userId, AddNewDriverFormModel model, string type, ModelStateDictionary modelState)
        {
            ICollection<Exception> errors = this.validator.ValidateDriver(model, modelState);

            if (errors.Count() == 0) await addService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age, model.TeamName, isModerator, userId);

            return errors;
        }
        public async Task<ICollection<Exception>> AddChampionship(bool isModerator, string userId, AddNewChampionshipFormModel model, string type, ModelStateDictionary modelState)
        {
            ICollection<Exception> errors = this.validator.ValidateChampionship(model, modelState);

            if (errors.Count() == 0) await addService.AddNewChampionship(model.Name, model.LogoUrl, isModerator, userId);

            return errors;
        }

    }
}
