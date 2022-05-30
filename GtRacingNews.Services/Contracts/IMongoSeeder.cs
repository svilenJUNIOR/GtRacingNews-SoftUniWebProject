namespace GtRacingNews.Services.Contracts
{
    public interface IMongoSeeder
    {
        public void SeedDriver();

        public void SeedProfiles();

        public void SeedTeams();

        public void SeedChampionship();

        public void SeedComments();

        public void SeedNews();

        public void SeedRaces();
    }
}
