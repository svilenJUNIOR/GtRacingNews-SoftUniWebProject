using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class AddService : IAddService
    {
        private readonly IRepository repository;
        public AddService(IRepository repository) => this.repository = repository;

        public async Task AddNewTeam(Type type, string name, string carModel, string logoUrl, string championshipName)
        {
            var championship = repository.FindChampionshipByName(championshipName);
            var team = Activator.CreateInstance(type, name, carModel, logoUrl, championship.Id);

            await repository.AddAsync<Team>((Team)team);
        }
        public async Task AddNewChampionship(Type type, string name, string logoUrl)
        {
            var championship = Activator.CreateInstance(type, name, logoUrl);
            await repository.AddAsync<Championship>((Championship)championship);
        }
        public async Task AddNewComment(Type type, string Description, int newsId, string UserName)
        {
            var comment = Activator.CreateInstance(type, Description, newsId, UserName);
            await repository.AddAsync<Comment>((Comment)comment);
        }
        public async Task AddNewDriver(Type type, string name, string cup, string imageUrl, int age, string teamName)
        {
            var team = repository.FindTeamByName(teamName);
            var driver = Activator.CreateInstance(type, name, age, cup, imageUrl, team.Id);

            await repository.AddAsync<Driver>((Driver)driver);
        }
        public async Task AddNews(Type type, string heading, string description, string pictureUrl)
        {
            var news = Activator.CreateInstance(type, heading, description, pictureUrl);
            await repository.AddAsync<News>((News)news);
        }
        public async Task AddNewRace(Type type, string name, string date)
        {
            var race = Activator.CreateInstance(type, name, date);
            await repository.AddAsync<Race>((Race)race);
        }
        public async Task AddNewProfile(Type type, string address, int age, string userId, string profileType)
        {
            var profile = Activator.CreateInstance(type, age, profileType, userId, address);
            await repository.AddAsync<Profile>((Profile)profile);
        }
    }
}