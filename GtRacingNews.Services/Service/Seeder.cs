using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace GtRacingNews.Services.Service
{
    public class Seeder : ISeederService
    {
        private readonly IRepository repository;
        public Seeder(IRepository repository) => this.repository = repository;

        public async Task SeedDriver()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Driver.json");

            var toAdd = JsonConvert.DeserializeObject<List<Driver>>(jsonString);

            await repository.AddRangeAsync<Driver>(toAdd);
        }

        public async Task SeedTeams()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Team.json");

            var toAdd = JsonConvert.DeserializeObject<List<Team>>(jsonString);

            await repository.AddRangeAsync<Team>(toAdd);
        }

        public async Task SeedChampionship()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Championship.json");

            var toAdd = JsonConvert.DeserializeObject<List<Championship>>(jsonString);

            await repository.AddRangeAsync<Championship>(toAdd);
        }

        public async Task SeedComments()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Comment.json");

            var toAdd = JsonConvert.DeserializeObject<List<Comment>>(jsonString);

            await repository.AddRangeAsync<Comment>(toAdd);
        }

        public async Task SeedNews()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\News.json");

            var toAdd = JsonConvert.DeserializeObject<List<News>>(jsonString);

            await repository.AddRangeAsync<News>(toAdd);
        }

        public async Task SeedRaces()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Race.json");

            var toAdd = JsonConvert.DeserializeObject<List<Race>>(jsonString);

            await repository.AddRangeAsync<Race>(toAdd);
        }

        public async Task SeedRoles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Role.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityRole>>(jsonString);

            await repository.AddRangeAsync<IdentityRole>(toAdd);
        }

        public async Task SeedUser()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\User.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUser>>(jsonString);

            await repository.AddRangeAsync<IdentityUser>(toAdd);
        }

        public async Task SeedUserRoles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\UserRole.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUserRole<string>>>(jsonString);

            await repository.AddRangeAsync<IdentityUserRole<string>>(toAdd);
        }
    }
}
