using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> ValidateUserRegistration(RegisterUserFormModel model);
        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
    }
}
