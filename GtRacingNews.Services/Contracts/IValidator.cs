using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> ValidateUserRegistration(RegisterUserFormModel model);
        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<string> ValidateAddNews(AddNewFormModel model);
    }
}
