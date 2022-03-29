using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Service
{
    public class ReturnAll : IReturnAll
    {
        private readonly GTNewsDbContext context;

        public ReturnAll(GTNewsDbContext context) => this.context = context;

        public IEnumerable<object> All(string Entity)
        {
            
            if (Entity == "Teams")
            {
                var teams = context.Teams
                .Select(x => new ViewAllTeamsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    CarModel = x.CarModel,
                    ChampionshipName = context.Championships.Where(c => c.Id == x.ChampionshipId).FirstOrDefault().Name,
                    Drivers = context.Drivers.Where(d => d.TeamId == x.Id).Select(x => x.Name).ToList(),

                }).ToList();

                return teams;
            }

            if (Entity == "Races")
            {
                var races = context.Races
                .Select(x => new ViewAllRacesViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                });

                return races;
            }

            if (Entity == "News")
            {
                var news = context.News
               .Select(x => new ShowAllNewsViewModel
               {
                   Id = x.Id,
                   Heading = x.Heading,
                   ImgUrl = x.PictureUrl
               }).ToList();

                return news;
            }

            if (Entity == "Drivers")
            {
                var drivers = context.Drivers
                   .Select(x => new ViewAllDriversViewModel
                   {
                       
                       DriverId = x.Id,
                       Age = x.Age,
                       Cup = x.Cup,
                       Name = x.Name,
                       ImageUrl = x.ImageUrl,
                   }).ToList();

                return drivers;
            }

            if (Entity == "Championships")
            {
                var championships = context.Championships
                .Select(x => new ViewAllChampionshipsViewModel
                {
                    ChampionshipId = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    Teams = context.Teams.Where(t => t.ChampionshipId == x.Id).Select(t => t.Name).ToList()
                }).ToList();

                return championships;
            }

            return null;
        }

        public ReadNewsViewModel NewsDeatils(int newsId)
        {
            var news = context.News.Where(x => x.Id == newsId)
                .Select(n => new ReadNewsViewModel
                {
                    NewsId = n.Id,
                    Description = n.Description,
                    Comments = context.Comments.Where(x => x.NewsId == n.Id).ToList()
                }).FirstOrDefault();

            return news;
        }
    }
}
