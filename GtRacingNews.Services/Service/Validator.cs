using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using GtRacingNews.Common.Constants;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        private readonly IHasher hasher = new Hasher();
        private readonly GTNewsDbContext context = new GTNewsDbContext();

        public IEnumerable<string> ValidateUserLogin(LoginUserFormModel model)
        {
            var errors = new List<string>();

            if (!context.Users.Any(x => x.Email == model.Email))
                errors.Add(Messages.UnExistingEmail);

            if (!context.Users.Any(x => x.Password == hasher.Hash(model.Password)))
                errors.Add(Messages.UnExistingPassword);

            return errors;
        }

        public IEnumerable<string> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (!model.Email.EndsWith(Values.EndOfAnEmail))
                errors.Add(string.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail));

            if (model.Password.Length < Values.MinPasswordLength || model.Password.Length > Values.MaxPasswordLength)
                errors.Add(string.Format(Messages.WrongPasswordFormat, Values.MinPasswordLength, Values.MaxPasswordLength));

            if (model.Username.Length < Values.MinUsernameLength || model.Username.Length > Values.MaxUsernameLength)
                errors.Add(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength));

            if (model.Password != model.ConfirmPassword)
                errors.Add(Messages.PasswordsDontMatch);

            if (context.Users.Any(x => x.Email == model.Email))
                errors.Add(Messages.ExistingEmail);

            if (context.Users.Any(x => x.Username == model.Username))
                errors.Add(Messages.ExistingUsername);

            if (context.Users.Any(x => x.Password == model.Password))
                errors.Add(Messages.ExistingPassword);

            return errors;
        }
    }
}
