namespace GtRacingNews.Services.Contracts
{
    public interface ISeederService
    {
        public Task SeedDriver();

        public Task SeedTeams();

        public Task SeedChampionship();

        public Task SeedComments();

        public Task SeedNews();

        public Task SeedRaces();

        public Task SeedRoles();

        public Task SeedUser();

        public Task SeedUserRoles();
    }
}
