using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        ICollection<Exception> AgainstNull(params string[] args);
        IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary ModelState);

        ICollection<Exception> ValidateObject(string dbset, string check, ModelStateDictionary ModelState);
        
    }
}
