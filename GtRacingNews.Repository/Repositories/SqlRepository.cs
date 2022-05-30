using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using Microsoft.AspNetCore.Identity;

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
        public IdentityUser FindUserByEmail(string email)
        {
            var user = context.Users.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }
        public IdentityUser FindUserById(string Id)
        {
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();
            return user;
        }
        public IdentityRole FindRoleById(string Id)
        {
            var role = roleManager.Roles.Where(x => x.Id == Id).FirstOrDefault();
            return role;
        }

        public void SaveChangesAsync() => this.context.SaveChangesAsync();
        public Profile FindProfileByUserId(string Id) => context.Profiles.Where(x => x.UserId == Id).FirstOrDefault();
        public List<T> GettAll<T>() where T : class => context.Set<T>().ToList();
        public Team FindTeamById(string Id) => context.Teams.Where(x => x.Id == Id).FirstOrDefault();
        public Championship FindChampionshipById(string? Id) => context.Championships.Where(x => x.Id == Id).FirstOrDefault();
        public Driver FindDriverById(string Id) => context.Drivers.Where(x => x.Id == Id).FirstOrDefault();
        public Comment FindCommentById(string Id) => context.Comments.Where(x => x.Id == Id).FirstOrDefault();
        public Race FindRaceById(string Id) => context.Races.Where(x => x.Id == Id).FirstOrDefault();
        public News FindNewsById(string Id) => context.News.Where(x => x.Id == Id).FirstOrDefault();

        public Team FindTeamByName(string name) => context.Teams.Where(x => x.Name == name).FirstOrDefault();
        public Championship FindChampionshipByName(string name) => context.Championships.Where(x => x.Name == name).FirstOrDefault();
        public Driver FindDriverByName(string name) => context.Drivers.Where(x => x.Name == name).FirstOrDefault();
        public Race FindRaceByName(string name) => context.Races.Where(x => x.Name == name).FirstOrDefault();
        public News FindNewsByName(string name) => context.News.Where(x => x.Heading == name).FirstOrDefault();
    }
}
