using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Contracts
{
    public interface IGuard
    {
        ICollection<string> AgainstNull(params string[] args);
    }
}
