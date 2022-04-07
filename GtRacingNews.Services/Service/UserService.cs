using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IHasher hasher;
        private readonly IValidator validator;
        private readonly IRepository repository;
        public UserService(IHasher hasher, IValidator validator, IRepository repository)
        {
            this.hasher = hasher;
            this.validator = validator;
            this.repository = repository;
        }

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
