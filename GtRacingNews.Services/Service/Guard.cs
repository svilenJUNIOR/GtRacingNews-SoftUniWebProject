using GtRacingNews.Common.Constants;
using GtRacingNews.Services.Contracts;

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
    }
}
