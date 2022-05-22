namespace GtRacingNews.Services.Contracts
{
    public interface IAddService
    {
        Task AddNewTeam(string name, string carModel, string logoUrl, string championshipName, bool isModerator, string userId);
        Task AddNewChampionship(string name, string logoUrl, bool isModerator, string userId);
        Task AddNewComment(string Description, string newsId, string UserName);
        Task AddNewDriver(string name, string cup, string imageUrl, int age, string teamName, bool isModerator, string userId);
        Task AddNews(string heading, string description, string pictureUrl, bool isModerator, string userId);
        Task AddNewRace(string name, string date, bool isModerator, string userId);
        Task AddNewProfile(string address, int age, string userId, string profileType, string profilePicture);
    }
}
