using GtRacingNews.Data.DataModels;

namespace GtRacingNews.Services.Contracts
{
    public interface IUserService
    {
        User RegisterUser(string email, string password, string username);
        void LoginUser(string email, string password);
    }
}
