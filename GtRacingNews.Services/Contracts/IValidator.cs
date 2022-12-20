using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        ICollection<Exception> ValidateChampionship(AddNewChampionshipFormModel model, ModelStateDictionary modelState);
        ICollection<Exception> ValidateDriver(AddNewDriverFormModel model, ModelStateDictionary modelState);
        ICollection<Exception> ValidateNews(AddNewFormModel model, ModelStateDictionary modelState);
        ICollection<Exception> ValidateRace(AddNewRaceFormModel model, ModelStateDictionary modelState);
        ICollection<Exception> ValidateTeam(AddTeamFormModel model, string type, ModelStateDictionary modelState);
        IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState);
        IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model);
        ICollection<Exception> CollectErrors(IEnumerable<Exception> dataErrors, IEnumerable<Exception> nullErrors, ModelStateDictionary modelState);
    }
}
