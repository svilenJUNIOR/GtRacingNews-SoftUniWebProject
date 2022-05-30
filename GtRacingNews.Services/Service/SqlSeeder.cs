using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace GtRacingNews.Services.Service
{
    public class SqlSeeder : ISqlSeeder
    {
        private readonly ISqlRepository sqlRepository;
        public SqlSeeder(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;
        public async Task SeedDriver()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Driver.json");

            var toAdd = JsonConvert.DeserializeObject<List<Driver>>(jsonString);

            await sqlRepository.AddRangeAsync<Driver>(toAdd);
        }

        public async Task SeedTeams()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Team.json");

            var toAdd = JsonConvert.DeserializeObject<List<Team>>(jsonString);

            await sqlRepository.AddRangeAsync<Team>(toAdd);
        }

        public async Task SeedChampionship()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Championship.json");

            var toAdd = JsonConvert.DeserializeObject<List<Championship>>(jsonString);

            await sqlRepository.AddRangeAsync<Championship>(toAdd);
        }

        public async Task SeedComments()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Comment.json");

            var toAdd = JsonConvert.DeserializeObject<List<Comment>>(jsonString);

            await sqlRepository.AddRangeAsync<Comment>(toAdd);
        }

        public async Task SeedNews()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\News.json");

            var toAdd = JsonConvert.DeserializeObject<List<News>>(jsonString);

            await sqlRepository.AddRangeAsync<News>(toAdd);
        }

        public async Task SeedRaces()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Race.json");

            var toAdd = JsonConvert.DeserializeObject<List<Race>>(jsonString);

            await sqlRepository.AddRangeAsync<Race>(toAdd);
        }

        public async Task SeedRoles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Role.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityRole>>(jsonString);

            await sqlRepository.AddRangeAsync<IdentityRole>(toAdd);
        }

        public async Task SeedUser()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\User.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUser>>(jsonString);

            await sqlRepository.AddRangeAsync<IdentityUser>(toAdd);
        }

        public async Task SeedUserRoles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\UserRole.json");

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUserRole<string>>>(jsonString);

            await sqlRepository.AddRangeAsync<IdentityUserRole<string>>(toAdd);
        }

        public async Task SeedProfiles()
        {
            var jsonString = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\SeederData\Profile.json");

            var toAdd = JsonConvert.DeserializeObject<List<Profile>>(jsonString);

            await sqlRepository.AddRangeAsync<Profile>(toAdd);
        }
    }
}
