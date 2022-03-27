using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Repository;

namespace GtRacingNews.Services.Service
{
    public class AddService : IAddService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        private readonly IRepository<Team> teamRepository;
        private readonly IRepository<Championship> championshipRepository;
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<Race> raceRepository;
        private readonly IRepository<Driver> driverRepository;
        private readonly IRepository<News> newsRepository;

        public AddService(
            IRepository<Team> teamRepository, 
            IRepository<Championship> championshipRepository,
            IRepository<Comment> commentRepository,
            IRepository<Race> raceRepository,
            IRepository<Driver> driverRepository,
            IRepository<News> newsRepository)
        {
            this.teamRepository = teamRepository;
            this.championshipRepository = championshipRepository;
            this.commentRepository = commentRepository;
            this.raceRepository = raceRepository;
            this.driverRepository = driverRepository;
            this.newsRepository = newsRepository;
        }

        public async Task AddNewTeam(Type type, string name, string carModel, string logoUrl, string championshipName)
        {
            var championship = context.Championships.Where(x => x.Name == championshipName).FirstOrDefault();
            var team = Activator.CreateInstance(type, name, carModel, logoUrl, championship.Id);

            await teamRepository.AddAsync((Team)team);
        }
        public async Task AddNewChampionship(Type type, string name, string logoUrl)
        {
            var championship = Activator.CreateInstance(type, name, logoUrl);

            await championshipRepository.AddAsync((Championship)championship);
        }
        public async Task AddNewComment(Type type, string Description, int newsId, string UserName)
        {
            var comment = Activator.CreateInstance(type, Description, newsId, UserName);

            await commentRepository.AddAsync((Comment)comment);
        }
        public async Task AddNewDriver(Type type, string name, string cup, string imageUrl, int age, string teamName)
        {
            var team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();

            var driver = Activator.CreateInstance(type, name, age, cup, imageUrl, team.Id);

            driverRepository.AddAsync((Driver)driver);
        }
        public async Task AddNews(Type type, string heading, string description, string pictureUrl)
        {
            var news = Activator.CreateInstance(type, heading, description, pictureUrl);

            newsRepository.AddAsync((News)news);
        }
        public async Task AddNewRace(Type type, string name, string date)
        {
            var race = Activator.CreateInstance(type, name, date);

            raceRepository.AddAsync((Race)race);
        }
    }
}