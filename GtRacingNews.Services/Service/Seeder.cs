using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace GtRacingNews.Services.Service
{
    public class Seeder
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();

        public async Task SeedDriver()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Driver.json");

            var toAdd = JsonConvert.DeserializeObject<List<Driver>>(jsonString);

            await context.Drivers.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedTeams()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Team.json");

            var toAdd = JsonConvert.DeserializeObject<List<Team>>(jsonString);

            await context.Teams.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedChampionship()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Championship.json");

            var toAdd = JsonConvert.DeserializeObject<List<Championship>>(jsonString);

            await context.Championships.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedComments()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Comment.json");

            var toAdd = JsonConvert.DeserializeObject<List<Comment>>(jsonString);

            await context.Comments.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedNews()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\News.json");

            var toAdd = JsonConvert.DeserializeObject<List<News>>(jsonString);

            await context.News.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedRaces()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Race.json");

            var toAdd = JsonConvert.DeserializeObject<List<Race>>(jsonString);

            await context.Races.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedRoles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Role.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityRole>>(jsonString);

            await context.Roles.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedUser()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\User.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUser>>(jsonString);

            await context.Users.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }

        public async Task SeedUserRoles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\UserRole.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUserRole<string>>>(jsonString);

            await context.UserRoles.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }
    }
}
