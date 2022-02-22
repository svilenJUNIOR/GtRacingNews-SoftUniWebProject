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
        private readonly Values values = new Values();
        private readonly Messages messages = new Messages();
        public IEnumerable<string> ValidateUserLogin(LoginUserFormModel model)
        {
            var errors = new List<string>();



            return errors;
        }

        public IEnumerable<string> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (!model.Email.EndsWith(Values.EndOfAnEmail))
            {
                errors.Add(string.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail));
            }

            return errors;
        }
    }
}
