namespace GtRacingNews.Services.Contracts
{
    public interface ITeamService
    {
        void AddNewTeam(string name, string carModel, string logoUrl, string championshipName);
    }
}
