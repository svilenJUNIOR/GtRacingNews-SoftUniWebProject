using GtRacingNews.Common.Constants;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Others
{
    public class Guard : IGuard
    {
        public IEnumerable<Exception> AgainstNull(params string[] args)
        {
            var errors = new List<Exception>();
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            if (check) errors.Add(new ArgumentNullException(Messages.NullField));

            return errors;
        }
        public IEnumerable<Exception> CheckModelState(ModelStateDictionary modelState)
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
        public ICollection<Exception> CollectErrors(IEnumerable<Exception> nullErrors, IEnumerable<Exception> modelStateErrors)
        {
            var errors = new List<Exception>();

            if (nullErrors.Count() > 0)
                foreach (var error in nullErrors) errors.Add(new ArgumentException(error.Message));

            if (modelStateErrors.Count() > 0)
                foreach (var modelError in modelStateErrors) errors.Add(new ArgumentException(modelError.Message));

            if (errors.Count == 0) return new List<Exception>();

            throw new AggregateException(errors);
        }

        public IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState)
        {
            var nullErrors = guard.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<Exception>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.ExistingEmail));
            if (users.Any(x => x.UserName == model.Username)) errors.Add(new ArgumentException(Messages.ExistingUsername));
            if (!model.Email.EndsWith("@email.com")) errors.Add(new ArgumentException(string.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail)));
            if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
                errors.Add(new ArgumentException(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength)));

            var modelStateErrors = guard.CheckModelState(modelState);

            if (modelStateErrors.Count() > 0) errors.AddRange(modelStateErrors);

            return guard.ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model)
        {
            var nullErrors = guard.AgainstNull(model.Password, model.Email);
            if (nullErrors.Count() > 0) return nullErrors;

            var errors = new List<Exception>();
            var users = sqlRepository.GettAll<IdentityUser>();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.UnExistingEmail));
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(new ArgumentException(Messages.UnExistingPassword));

            return guard.ThrowErrors(errors);
        }
    }
}
