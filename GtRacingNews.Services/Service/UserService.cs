using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IEngine engine;
        public UserService(IEngine engine) => this.engine = engine;

        public IdentityUser RegisterUser(RegisterUserFormModel model)
        {
            var user = new IdentityUser();

            user.Email = model.Email;
            user.UserName = model.Username;
            user.PasswordHash = engine.hasher.Hash(model.Password);

            return user;
        }
    }
}
