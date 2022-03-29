using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        private readonly GTNewsDbContext context;
        private readonly IHasher hasher;
        public Validator(GTNewsDbContext context, IHasher hasher)
        {
            this.context = context;
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

        public IEnumerable<string> ValidateForm(ModelStateDictionary modelState)
        {
            var errors = new List<string>();

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

        public IEnumerable<string> ValidateUserLogin(LoginUserFormModel model)
        {
            var errors = new List<string>();
            var users = context.Users.ToList();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(Messages.UnExistingEmail);
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(Messages.UnExistingPassword);

            return errors;
        }
        public IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model)
        {
            var errors = new List<string>();
            var users = context.Users.ToList();

            if (users.Any(x => x.Email == model.Email)) errors.Add(Messages.ExistingEmail);
            if (users.Any(x => x.UserName == model.Username)) errors.Add(Messages.ExistingUsername);
            if (!model.Email.EndsWith("@email.com")) errors.Add(String.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail));

            if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
                errors.Add(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength));

            if (model.Password.Length < Values.MinPasswordLength)
                errors.Add(string.Format(Messages.WrongPasswordFormat, Values.MinUsernameLength));

            if (model.Password != model.ConfirmPassword) errors.Add(Messages.PasswordsDontMatch);

            return errors;
        }

        public IEnumerable<string> ValidateObject(string dbset, string check, ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            switch (dbset)
            {
                case "News": 
                    if (context.News.Any(x => x.Heading == check)) errors.Add(Messages.ExistingNews); break;

                case "Team":
                    if (context.Teams.Any(x => x.Name == check)) errors.Add(Messages.ExistingTeam); break;

                case "Championship":
                    if (context.Championships.Any(x => x.Name == check)) errors.Add(Messages.ExistingChampionship); break;

                case "Driver":
                    if (context.Drivers.Any(x => x.Name == check)) errors.Add(Messages.ExistingDriver); break;

                case "Race":
                    if (context.Races.Any(x => x.Name == check)) errors.Add(Messages.ExistingRace); break;

                default: break;
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
