using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class DeleteService: IDeleteService
    {
        private readonly GTNewsDbContext context;
        private readonly IRepository<Team> teamRepository;
        private readonly IRepository<Championship> championshipRepository;
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<Race> raceRepository;
        private readonly IRepository<Driver> driverRepository;
        private readonly IRepository<News> newsRepository;
        private readonly IRepository<IdentityUser> userRepository;

        public DeleteService(
            GTNewsDbContext context,
            IRepository<Team> teamRepository,
            IRepository<Championship> championshipRepository,
            IRepository<Comment> commentRepository,
            IRepository<Race> raceRepository,
            IRepository<Driver> driverRepository,
            IRepository<News> newsRepository,
            IRepository<IdentityUser> userRepository)
        {
            this.context = context;
            this.teamRepository = teamRepository;
            this.championshipRepository = championshipRepository;
            this.commentRepository = commentRepository;
            this.raceRepository = raceRepository;
            this.driverRepository = driverRepository;
            this.newsRepository = newsRepository;
            this.userRepository = userRepository;
        }

        public async Task Delete(string collection, int id)
        {
            switch (collection)
            {
                case "Team":
                    var team = context.Teams.Where(t => t.Id == id).FirstOrDefault();
                    await teamRepository.RemoveAsync(team);
                    break;

                case "Championship":
                    var championship = context.Championships.Where(t => t.Id == id).FirstOrDefault();
                    await championshipRepository.RemoveAsync(championship);
                    break;

                case "Comment":
                    var comment = context.Comments.Where(t => t.Id == id).FirstOrDefault();
                    await commentRepository.RemoveAsync(comment);
                    break;

                case "Race":
                    var race = context.Races.Where(t => t.Id == id).FirstOrDefault();
                    await raceRepository.RemoveAsync(race);
                    break;

                case "Driver":
                    var driver = context.Drivers.Where(t => t.Id == id).FirstOrDefault();
                    await driverRepository.RemoveAsync(driver);
                    break;

                case "News":
                    var news = context.News.Where(t => t.Id == id).FirstOrDefault();
                    await newsRepository.RemoveAsync(news);
                    break;

                default:
                    break;
            }
        }
        public async Task Delete(string id)
        {
            var user = context.Users.Where(x => x.Id == id).FirstOrDefault();

            await userRepository.RemoveAsync(user);
        }
    }
}
