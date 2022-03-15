namespace GtRacingNews.Services.Contracts
{
    public interface ITeamService
    {
        Task AddNewTeam(string name, string carModel, string logoUrl, string championshipName);
    }
}
