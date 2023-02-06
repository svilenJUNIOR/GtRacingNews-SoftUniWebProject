using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using GtRacingNews.Services.Others.Contracts;

namespace GtRacingNews.Services.Others
{
    public class SqlSeeder : ISqlSeeder
    {
        private readonly ISqlRepository sqlRepository;
        public SqlSeeder(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;

        public async Task SeedDriver()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Drivers);// SEED FILES PATH CLASS COMES FROM THE COMMON CONSTANTS USING

            var toAdd = JsonConvert.DeserializeObject<List<Driver>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedTeams()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Teams);

            var toAdd = JsonConvert.DeserializeObject<List<Team>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedChampionship()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Championships);

            var toAdd = JsonConvert.DeserializeObject<List<Championship>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedComments()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Comments);

            var toAdd = JsonConvert.DeserializeObject<List<Comment>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedNews()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.News);

            var toAdd = JsonConvert.DeserializeObject<List<News>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedRaces()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Races);

            var toAdd = JsonConvert.DeserializeObject<List<Race>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedProfiles()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Profiles);

            var toAdd = JsonConvert.DeserializeObject<List<Profile>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }

        public async Task SeedRoles()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Roles);

            var toAdd = JsonConvert.DeserializeObject<List<IdentityRole>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedUser()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Users);

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUser>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
        public async Task SeedUserRoles()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.UserRoles);

            var toAdd = JsonConvert.DeserializeObject<List<IdentityUserRole<string>>>(jsonString);

            await sqlRepository.AddRangeAsync(toAdd);
        }
    }
}
