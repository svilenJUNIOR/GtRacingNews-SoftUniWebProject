using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.User
{
    public interface IUserService
    {
        IdentityUser RegisterUser(RegisterUserFormModel model);
    }
}
