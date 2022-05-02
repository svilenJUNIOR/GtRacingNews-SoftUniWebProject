using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public interface IValidator
    {
        ICollection<string> AgainstNull(params string[] args);

        IEnumerable<string> ValidateForm(ModelStateDictionary modelState);
       
        IEnumerable<string> ValidateUserLogin(LoginUserFormModel model);
        IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model);

        ICollection<string> ValidateObject(string dbset, string check, ModelStateDictionary ModelState);
        
    }
}
