using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IHasher hasher = new Hasher();
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void LoginUser(string email, string password)
        {
           
        }

        public User RegisterUser(string email, string password, string username)
        {
            var user = new User
            {
                Email = email,
                Password = hasher.Hash(password),
                Username = username,
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
    }
}
