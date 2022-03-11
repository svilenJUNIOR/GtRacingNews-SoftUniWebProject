using GtRacingNews.Services.Contracts;
using GtRacingNews.Common.Constants;

namespace GtRacingNews.Services.Service
{
    public class Guard : IGuard
    {
        public ICollection<string> AgainstNull(params string[] args)
        {
            var errors = new List<string>();

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    errors.Add(Messages.NullField);

            errors.RemoveRange(1, errors.Count - 1);
            return errors;
        }
    }
}
