using GtRacingNews.Data.DataModels;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> ValidateForm(ModelStateDictionary ModelState);
        IEnumerable<string> ValidateAddTeamForm(AddTeamFormModel model);
        
        IEnumerable<string> ValidateAddNews(AddNewFormModel model);
        IEnumerable<string> ValidateAddRace(AddNewRaceFormModel model);
        IEnumerable<string> ValidateAddNewTeam(AddTeamFormModel model);
        IEnumerable<string> ValidateAddNewChampionship(AddNewChampionshipFormModel model);
        IEnumerable<string> ValidateAddNewDriver(AddNewDriverFormModel model);
        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model);
    }
}
