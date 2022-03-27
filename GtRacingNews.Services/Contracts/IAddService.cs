namespace GtRacingNews.Services.Contracts
{
    public interface IAddService
    {
        Task AddNewTeam(Type type, string name, string carModel, string logoUrl, string championshipName);
        Task AddNewChampionship(Type type, string name, string logoUrl);
        Task AddNewComment(Type type, string Description, int newsId, string UserName);
        Task AddNewDriver(Type type, string name, string cup, string imageUrl, int age, string teamName);
        Task AddNews(Type type, string heading, string description, string pictureUrl);
        Task AddNewRace(Type type, string name, string date);

    }
}
