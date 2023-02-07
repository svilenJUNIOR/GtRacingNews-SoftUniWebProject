using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Others.Contracts
{
    public interface IGuard
    {
        IEnumerable<Exception> ValidateTeam(string Name);
        IEnumerable<Exception> ValidateChampionship(string Name);
        IEnumerable<Exception> ValidateNews(string Heading);
        IEnumerable<Exception> ValidateRace(string Name);
        IEnumerable<Exception> ValidateDriver(string Name);
        IEnumerable<Exception> CollectModelStateErrors(ModelStateDictionary modelState);
        IEnumerable<Exception> AgainstNull(params string[] args);
        IEnumerable<Exception> CheckModelState(ModelStateDictionary modelState);
        IEnumerable<Exception> ThrowErrors(ICollection<Exception> errors);
    }
}
