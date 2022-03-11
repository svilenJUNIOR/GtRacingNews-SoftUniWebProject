using GtRacingNews.Services.Contracts;
using GtRacingNews.Common.Constants;
using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Service
{
    public class Guard : IGuard
    {
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

        public bool AgainstInvalidEmail(string email)
        {
            bool check = false;

            if (!email.EndsWith(Values.EndOfAnEmail)) check = true;

            return check;
        }
    }
}
