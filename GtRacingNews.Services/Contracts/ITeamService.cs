namespace GtRacingNews.Services.Contracts
{
    public interface ITeamService
    {
        void AddNewTeam(string name);
        void AddTeamToChampionship(int teamId, string championshipName);
    }
}
