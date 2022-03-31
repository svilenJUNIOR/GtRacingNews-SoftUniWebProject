using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace GtRacingNews.Services
{
    public class Repository : IRepository
    {
        private readonly GTNewsDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public Repository(RoleManager<IdentityRole> roleManager, GTNewsDbContext context)
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

        public ICollection<T> GettAll<T>() where T : class => context.Set<T>().ToList();
        public Team FindTeamById(int Id) => context.Teams.Where(x => x.Id == Id).FirstOrDefault();
        public Championship FindChampionshipById(int? Id) => context.Championships.Where(x => x.Id == Id).FirstOrDefault();
        public Driver FindDriverById(int Id) => context.Drivers.Where(x => x.Id == Id).FirstOrDefault();
        public Comment FindCommentById(int Id) => context.Comments.Where(x => x.Id == Id).FirstOrDefault();
        public Race FindRaceById(int Id) => context.Races.Where(x => x.Id == Id).FirstOrDefault();
        public News FindNewsById(int Id) => context.News.Where(x => x.Id == Id).FirstOrDefault();

        public Team FindTeamByName(string name) => context.Teams.Where(x => x.Name == name).FirstOrDefault();
        public Championship FindChampionshipByName(string name) => context.Championships.Where(x => x.Name == name).FirstOrDefault();
        public Driver FindDriverByName(string name) => context.Drivers.Where(x => x.Name == name).FirstOrDefault();
        public Race FindRaceByName(string name) => context.Races.Where(x => x.Name == name).FirstOrDefault();
        public News FindNewsByName(string name) => context.News.Where(x => x.Heading == name).FirstOrDefault();
    }
}
