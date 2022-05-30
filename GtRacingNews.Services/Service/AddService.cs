using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class AddService : IAddService
    {
        private readonly ISqlRepository sqlRepository;
        public AddService(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;
        public async Task AddNewTeam(string name, string carModel, string logoUrl, string championshipName, bool isModerator, string userId)
        {
            var championship = sqlRepository.FindChampionshipByName(championshipName);
            var team = new Team(name, carModel, logoUrl, championship.Id);

            if (isModerator) team.UserId = userId;

            await sqlRepository.AddAsync<Team>((Team)team);
        }
        public async Task AddNewChampionship(string name, string logoUrl, bool isModerator, string userId)
        {
            var championship = new Championship(name, logoUrl);
            if (isModerator) championship.UserId = userId;
            await sqlRepository.AddAsync<Championship>((Championship)championship);
        }
        public async Task AddNewDriver(string name, string cup, string imageUrl, int age, string teamName, bool isModerator, string userId)
        {
            var team = sqlRepository.FindTeamByName(teamName);
            var driver = new Driver(name, age, cup, imageUrl, team.Id);

            if (isModerator) driver.UserId = userId;

            await sqlRepository.AddAsync<Driver>((Driver)driver);
        }
        public async Task AddNews(string heading, string description, string pictureUrl, bool isModerator, string userId)
        {
            var news = new News(heading, description, pictureUrl);
            if (isModerator) news.UserId = userId;
            await sqlRepository.AddAsync<News>((News)news);
        }
        public async Task AddNewRace(string name, string date, bool isModerator, string userId)
        {
            var race = new Race(name, date);
            if (isModerator) race.UserId = userId;
            await sqlRepository.AddAsync<Race>((Race)race);
        }
        public async Task AddNewProfile(string address, int age, string userId, string profileType, string profilePicture)
        {
            var profile = new Profile(age, profileType, userId, address, profilePicture);
            await sqlRepository.AddAsync<Profile>((Profile)profile);
        }
        public async Task AddNewComment(string Description, string newsId, string UserName)
        {
            var comment = new Comment(Description, newsId, UserName);
            await sqlRepository.AddAsync<Comment>((Comment)comment);
        }
    }
}