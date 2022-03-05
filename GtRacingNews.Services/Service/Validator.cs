using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using GtRacingNews.Common.Constants;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Race;

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

            if (context.Users.Any(x => x.Password == hasher.Hash(model.Password)))
                errors.Add(Messages.ExistingPassword);

            return errors;
        }

        public IEnumerable<string> ValidateAddNews(AddNewFormModel model)
        {
            var errors = new List<string>();

            if (context.News.Any(x => x.Heading == model.Heading))
                errors.Add(Messages.ExistingNews);

            return errors;
        }

        public IEnumerable<string> ValidateAddNewTeam(AddTeamFormModel model)
        {
            var errors = new List<string>();

            if (context.Teams.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingTeam);

            return errors;
        }

        public IEnumerable<string> ValidateAddNewChampionship(AddNewChampionshipFormModel model)
        {
            var errors = new List<string>();

            if (context.Championships.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingChampionship);

            return errors;
        }

        public IEnumerable<string> ValidateAddNewDriver(AddNewDriverFormModel model)
        {
            var errors = new List<string>();

            if (context.Drivers.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingDriver);

            return errors;
        }

        public IEnumerable<string> ValidateAddDriverToTeam(int teamId)
        {
            var errors = new List<string>();

            var team = context.Teams.Where(x => x.Id == teamId).FirstOrDefault();

            if (team.Drivers.Count() >= 3) errors.Add(Messages.DriverListFull);

            return errors;
        }

        public IEnumerable<string> ValidateAddRace(AddNewRaceFormModel model)
        {
            var errors = new List<string>();

            if (context.Races.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingRace);

            return errors;
        }
    }
}
