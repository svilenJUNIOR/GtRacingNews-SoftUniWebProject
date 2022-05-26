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
        public ICollection<string> AgainstNull(params string[] args)
        {
            var errors = new List<string>();
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            if (check) errors.Add(Messages.NullField);

            return errors;
        }
        public IEnumerable<string> ValidateUserLogin(LoginUserFormModel model)
        {
            var nullErrors = AgainstNull(model.Password, model.Email);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<string>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(Messages.UnExistingEmail);
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(Messages.UnExistingPassword);

            return errors;
        }
        public IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<string>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (users.Any(x => x.Email == model.Email)) errors.Add(Messages.ExistingEmail);
            if (users.Any(x => x.UserName == model.Username)) errors.Add(Messages.ExistingUsername);
            if (!model.Email.EndsWith("@email.com")) errors.Add(String.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail));

            if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
                errors.Add(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength));

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
        public ICollection<string> ValidateObject(string dbset, string check, ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            if (dbset == "Team")
                if (sqlRepository.FindTeamByName(check) != null) errors.Add(Messages.ExistingTeam);

            if (dbset == "Championship")
                if (sqlRepository.FindChampionshipByName(check) != null) errors.Add(Messages.ExistingChampionship);

            if (dbset == "News")
                if (sqlRepository.FindNewsByName(check) != null) errors.Add(Messages.ExistingNews);

            if (dbset == "Race")
                if (sqlRepository.FindRaceByName(check) != null) errors.Add(Messages.ExistingRace);

            if (dbset == "Driver")
                if (sqlRepository.FindDriverByName(check) != null) errors.Add(Messages.ExistingDriver);

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
