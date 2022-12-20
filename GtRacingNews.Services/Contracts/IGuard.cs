using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public interface IGuard
    {
        IEnumerable<Exception> AgainstNull(params string[] args);
        IEnumerable<Exception> ValidateObject(string dbset, string check, ModelStateDictionary ModelState);
        IEnumerable<Exception> CheckModelState(ModelStateDictionary modelState);
        IEnumerable<Exception> ThrowErrors(ICollection<Exception> errors);
    }
}
