using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.User
{
    public class UserService : IUserService
    {
        private IHasher hasher;

        public UserService(IHasher hasher)
        =>  this.hasher = hasher;
        public IdentityUser RegisterUser(RegisterUserFormModel model)
        {
            var user = new IdentityUser();

            user.Email = model.Email;
            user.UserName = model.Username;
            user.PasswordHash = hasher.Hash(model.Password);

            return user;
        }
    }
}
