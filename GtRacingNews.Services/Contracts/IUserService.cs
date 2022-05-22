using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Contracts
{
    public interface IUserService
    {
        IdentityUser RegisterUser(RegisterUserFormModel model);
    }
}
