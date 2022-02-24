using GtRacingNews.ViewModels.Car;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> ValidateUserRegistration(RegisterUserFormModel model);
        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<string> ValidateAddNews(AddNewFormModel model);
        IEnumerable<string> ValidateAddNewTeam(AddTeamFormModel model);
        IEnumerable<string> ValidateAddNewChampionship(AddNewChampionshipFormModel model);
        IEnumerable<string> ValidateAddNewCar(AddNewCarFormModel model);
        IEnumerable<string> ValidateAddNewDriver(AddNewDriverFormModel model);
    }
}
