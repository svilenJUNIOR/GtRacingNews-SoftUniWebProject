using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Others.Contracts
{
    public interface IGuard
    {
        IEnumerable<Exception> AgainstNull(params string[] args);
        IEnumerable<Exception> CheckModelState(ModelStateDictionary modelState);
        IEnumerable<Exception> ThrowErrors(ICollection<Exception> errors);
        ICollection<Exception> CollectErrors(IEnumerable<Exception> nullErrors, IEnumerable<Exception> modelStateErrors);

        IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState);
        IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model);
    }
}
