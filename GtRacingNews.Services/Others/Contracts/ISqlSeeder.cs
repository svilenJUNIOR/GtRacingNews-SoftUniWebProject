namespace GtRacingNews.Services.Others.Contracts
{
    public interface ISqlSeeder
    {
        Task SeedDriver();
        Task SeedProfiles();
        Task SeedTeams();
        Task SeedChampionship();
        Task SeedComments();
        Task SeedNews();
        Task SeedRaces();
        Task SeedRoles();
        Task SeedUser();
        Task SeedUserRoles();
    }
}
