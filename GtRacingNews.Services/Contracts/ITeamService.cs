namespace GtRacingNews.Services.Contracts
{
    public interface ITeamService
    {
        void AddNewTeam(string name, string carModel);
        void AddTeamToChampionship(int teamId, string championshipName);
    }
}
