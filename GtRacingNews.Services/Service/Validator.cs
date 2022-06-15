using GtRacingNews.Common.Constants;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        private readonly ISqlRepository sqlRepository;
        private readonly IHasher hasher;
        public Validator(ISqlRepository sqlRepository, IHasher hasher)
        {
            this.sqlRepository = sqlRepository;
            this.hasher = hasher;
        }
        public IEnumerable<Exception> AgainstNull(params string[] args)
        {
            var errors = new List<Exception>();
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            if (check) errors.Add(new ArgumentException(Messages.NullField));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateObject(string dbset, string check, ModelStateDictionary modelState)
        {
            var errors = new List<Exception>();

            if (dbset == "Team")
                if (sqlRepository.FindTeamByName(check) != null) errors.Add(new ArgumentException(Messages.ExistingTeam));

            if (dbset == "Championship")
                if (sqlRepository.FindChampionshipByName(check) != null) errors.Add(new ArgumentException(Messages.ExistingChampionship));

            if (dbset == "News")
                if (sqlRepository.FindNewsByName(check) != null) errors.Add(new ArgumentException(Messages.ExistingNews));

            if (dbset == "Race")
                if (sqlRepository.FindRaceByName(check) != null) errors.Add(new ArgumentException(Messages.ExistingRace));

            if (dbset == "Driver")
                if (sqlRepository.FindDriverByName(check) != null) errors.Add(new ArgumentException(Messages.ExistingDriver));

            var modelStateErrors = CheckModelState(modelState);

            if (modelStateErrors.Count() > 0) errors.AddRange(modelStateErrors);

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model)
        {
            var nullErrors = AgainstNull(model.Password, model.Email);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<Exception>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.UnExistingEmail));
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(new ArgumentException(Messages.UnExistingPassword));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<Exception>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.ExistingEmail));
            if (users.Any(x => x.UserName == model.Username)) errors.Add(new ArgumentException(Messages.ExistingUsername));
            if (!model.Email.EndsWith("@email.com")) errors.Add(new ArgumentException(String.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail)));
            if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
                errors.Add(new ArgumentException(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength)));

            var modelStateErrors = CheckModelState(modelState);

            if (modelStateErrors.Count() > 0) errors.AddRange(modelStateErrors);

            return ThrowErrors(errors);
        }

        private IEnumerable<Exception> CheckModelState(ModelStateDictionary modelState)
        {
            var errors = new List<Exception>();

            if (!modelState.IsValid)
                foreach (var values in modelState.Values)
                    foreach (var modelError in values.Errors)
                        errors.Add(new ArgumentException(modelError.ErrorMessage));

            return errors;
        }
        public IEnumerable<Exception> ThrowErrors(ICollection<Exception> errors)
        {
            if (errors.Count == 0) return new List<Exception>();
            throw new AggregateException(errors);
        }
    }
}
