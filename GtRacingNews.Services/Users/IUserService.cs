using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.User
{
    public interface IUserService
    {
        public IdentityUser RegisterUser(RegisterUserFormModel model);
    }
}
