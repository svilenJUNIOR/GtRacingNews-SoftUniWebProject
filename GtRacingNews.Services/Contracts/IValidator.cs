using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> ValidateUserRegistration(RegisterUserFormModel model);
        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<string> ValidateAddNews(AddNewFormModel model);
        IEnumerable<string> ValidateAddRace(AddNewRaceFormModel model);
        IEnumerable<string> ValidateAddNewTeam(AddTeamFormModel model);
        IEnumerable<string> ValidateAddNewChampionship(AddNewChampionshipFormModel model);
        IEnumerable<string> ValidateAddNewDriver(AddNewDriverFormModel model);
        IEnumerable<string> ValidateAddDriverToTeam(int teamId);
    }
}
