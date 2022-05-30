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
        public IValidator validator { get; set; }
        public ISqlRepository sqlRepository { get; set; }
        public IMongoRepository mongoRepository { get; set; }
        public IMongoSeeder mongoSeeder { get; set; }
        public IProfileService profileService { get; set; }
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
                IMongoRepository mongoRepository,
                IMongoSeeder mongoSeeder,
                IProfileService profileService,
                IUserService userService
            )
        {
            this.addService = addService;
            this.bindService = bindService;
            this.deleteService = deleteService;
            this.returnAll = returnAll;
            this.seeder = seeder;
            this.validator = validator;
            this.sqlRepository = sqlRepository;
            this.mongoRepository = mongoRepository;
            this.mongoSeeder = mongoSeeder;
            this.profileService = profileService;
            this.userService = userService;
        }

        public async Task<ICollection<string>> AddTeam(bool isModerator, string userId, AddTeamFormModel model, string type, ModelStateDictionary modelState)
        {
            var nullErrors = validator.AgainstNull(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
            var dataErrors = validator.ValidateObject(type, model.Name, modelState);

            var errors = CollectErrors(dataErrors, nullErrors, modelState);

            if (errors.Count() == 0) await addService.AddNewTeam(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName, isModerator, userId);

            return errors;
        }

        public async Task<ICollection<string>> AddNews(bool isModerator, string userId, AddNewFormModel model, string type, ModelStateDictionary modelState)
        {
            var nullErrors = validator.AgainstNull(model.Heading, model.Description, model.PictureUrl);
            var dataErrors = validator.ValidateObject("News", model.Heading, modelState);

            var errors = CollectErrors(dataErrors, nullErrors, modelState);

            if (errors.Count() == 0) await addService.AddNews(model.Heading, model.Description, model.PictureUrl, isModerator, userId);

            return errors;
        }

        public async Task<ICollection<string>> AddRace(bool isModerator, string userId, AddNewRaceFormModel model, string type, ModelStateDictionary modelState)
        {
            var nullErrors = validator.AgainstNull(model.Name, model.Date);
            var dataErrors = validator.ValidateObject("Race", model.Name, modelState);

            var errors = CollectErrors(dataErrors, nullErrors, modelState);

            if (errors.Count() == 0) await addService.AddNewRace(model.Name, model.Date, isModerator, userId);

            return errors;
        }

        public async Task<ICollection<string>> AddDriver(bool isModerator, string userId, AddNewDriverFormModel model, string type, ModelStateDictionary modelState)
        {
            var nullErrors = validator.AgainstNull(model.TeamName, model.Age.ToString(), model.ImageUrl, model.Cup);
            var dataErrors = validator.ValidateObject("Driver", model.Name, modelState);

            var errors = CollectErrors(dataErrors, nullErrors, modelState);

            if (errors.Count() == 0) await addService.AddNewDriver(model.Name, model.Cup, model.ImageUrl, model.Age, model.TeamName, isModerator, userId);

            return errors;
        }

        public async Task<ICollection<string>> AddChampionship(bool isModerator, string userId, AddNewChampionshipFormModel model, string type, ModelStateDictionary modelState)
        {
            var nullErrors = validator.AgainstNull(model.Name, model.LogoUrl);
            var dataErrors = validator.ValidateObject("Championship", model.Name, modelState);

            var errors = CollectErrors(dataErrors, nullErrors, modelState);

            if (errors.Count() == 0) await addService.AddNewChampionship(model.Name, model.LogoUrl, isModerator, userId);

            return errors;
        }

        public ICollection<string> CollectErrors(ICollection<string> dataErrors, ICollection<string> nullErrors, ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            if (dataErrors.Count() > 0)
            {
                foreach (var error in dataErrors) errors.Add(error);
            }

            if (nullErrors.Count() > 0)
            {
                foreach (var error in nullErrors) errors.Add(error);
            }

            if (!modelState.IsValid)
            {
                foreach (var values in modelState.Values)
                {
                    foreach (var modelError in values.Errors)
                    {
                        errors.Add(modelError.ErrorMessage);
                    }
                }
            }

            return errors;
        }
    }
}
