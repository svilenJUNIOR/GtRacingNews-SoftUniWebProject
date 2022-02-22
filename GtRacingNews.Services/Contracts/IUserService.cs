namespace GtRacingNews.Services.Contracts
{
    public interface IUserService
    {
        void RegisterUser(string email, string password, string username);
        void LoginUser(string email, string password);
    }
}
