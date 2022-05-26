using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        ICollection<string> AgainstNull(params string[] args);

        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary ModelState);

        ICollection<string> ValidateObject(string dbset, string check, ModelStateDictionary ModelState);
        
    }
}
