using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GtRacingNews.Repository.Repositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly SqlDBContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public SqlRepository(RoleManager<IdentityRole> roleManager, SqlDBContext context)
        {
            this.roleManager = roleManager;
            this.context = context;
        }
        public async Task AddAsync<T>(T newItem) where T : class
        {
            await context.Set<T>().AddAsync(newItem);
            await context.SaveChangesAsync();
        }
        public async Task AddRangeAsync<T>(List<T> newItems) where T : class
        {
            await context.Set<T>().AddRangeAsync(newItems);
            await context.SaveChangesAsync();
        }
        public async Task RemoveAsync<T>(T item) where T : class
        {
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }
        public void SaveChangesAsync() => this.context.SaveChangesAsync();
        public ICollection<T> GettAll<T>() where T : class => context.Set<T>().ToList();

        public IdentityUser FindUserByEmail(string email) => context.Users.Where(x => x.Email == email).FirstOrDefault();
        public IdentityUser FindUserById(string Id) => context.Users.Where(x => x.Id == Id).FirstOrDefault();
        public IdentityRole FindRoleById(string Id) => roleManager.Roles.Where(x => x.Id == Id).FirstOrDefault();

        public T FindById<T> (string Id) where T : class
        {
            DbSet<T> table = context.Set<T>();
            return table.Find(Id);
        }

        public Profile FindByUserId(string UserId) => context.Profiles.Where(x => x.UserId == UserId).FirstOrDefault();
    }
}
