using GtRacingNews.Common.Constants;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        public IGuard guard { get; set; }
        public ISqlRepository sqlRepository { get; set; }
        public IHasher hasher { get; set; }

        public Validator(IGuard guard, ISqlRepository sqlRepository, IHasher hasher)
        {
            this.guard = guard;
            this.sqlRepository = sqlRepository;
            this.hasher = hasher;
        }

        public ICollection<Exception> ValidateChampionship(AddNewChampionshipFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.LogoUrl);
            var dataErrors = guard.ValidateObject("Championship", model.Name, modelState);

            return CollectErrors(dataErrors, nullErrors, modelState);
        }
        public ICollection<Exception> ValidateDriver(AddNewDriverFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = guard.AgainstNull(model.TeamName, model.Age.ToString(), model.ImageUrl, model.Cup);
            var dataErrors = guard.ValidateObject("Driver", model.Name, modelState);

            return CollectErrors(dataErrors, nullErrors, modelState);
        }
        public ICollection<Exception> ValidateNews(AddNewFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = guard.AgainstNull(model.Heading, model.Description, model.PictureUrl);
            var dataErrors = guard.ValidateObject("News", model.Heading, modelState);

            return CollectErrors(dataErrors, nullErrors, modelState);
        }
        public ICollection<Exception> ValidateRace(AddNewRaceFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.Date);
            var dataErrors = guard.ValidateObject("Race", model.Name, modelState);

            return CollectErrors(dataErrors, nullErrors, modelState);
        }
        public ICollection<Exception> ValidateTeam(AddTeamFormModel model, string type, ModelStateDictionary modelState)
        {
            var nullErrors = guard.AgainstNull(model.Name, model.CarModel, model.LogoUrl, model.ChampionshipName);
            var dataErrors = guard.ValidateObject(type, model.Name, modelState);

            return CollectErrors(dataErrors, nullErrors, modelState);
        }
        
        public IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = this.guard.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<Exception>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.ExistingEmail));
            if (users.Any(x => x.UserName == model.Username)) errors.Add(new ArgumentException(Messages.ExistingUsername));
            if (!model.Email.EndsWith("@email.com")) errors.Add(new ArgumentException(String.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail)));
            if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
                errors.Add(new ArgumentException(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength)));

            var modelStateErrors = this.guard.CheckModelState(modelState);

            if (modelStateErrors.Count() > 0) errors.AddRange(modelStateErrors);

            return this.guard.ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model)
        {
            var nullErrors = this.guard.AgainstNull(model.Password, model.Email);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<Exception>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.UnExistingEmail));
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(new ArgumentException(Messages.UnExistingPassword));

            return this.guard.ThrowErrors(errors);
        }
        
        public ICollection<Exception> CollectErrors(IEnumerable<Exception> dataErrors, IEnumerable<Exception> nullErrors, ModelStateDictionary modelState)
        {
            var errors = new List<Exception>();

            if (dataErrors.Count() > 0)
                foreach (var error in dataErrors) errors.Add(new ArgumentException(error.Message));

            if (nullErrors.Count() > 0)
                foreach (var error in nullErrors) errors.Add(new ArgumentException(error.Message));

            if (!modelState.IsValid)
                foreach (var values in modelState.Values)
                    foreach (var modelError in values.Errors)
                        errors.Add(new ArgumentException(modelError.ErrorMessage));

            if (errors.Count == 0) return new List<Exception>();

            throw new AggregateException(errors);
        }
    }
}
