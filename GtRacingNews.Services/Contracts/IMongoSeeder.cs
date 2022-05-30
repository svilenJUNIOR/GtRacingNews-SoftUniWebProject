namespace GtRacingNews.Services.Contracts
{
    public interface IMongoSeeder
    {
        public Task SeedDriver();

        public Task SeedProfiles();

        public Task SeedTeams();

        public Task SeedChampionship();

        public Task SeedComments();

        public Task SeedNews();

        public Task SeedRaces();
    }
}
