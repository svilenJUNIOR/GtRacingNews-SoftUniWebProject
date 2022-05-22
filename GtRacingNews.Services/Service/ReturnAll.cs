using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Service
{
    public class ReturnAll : IReturnAll
    {
        private readonly ISqlRepoisitory sqlRepository;
        private readonly IBindService bindService;
        public ReturnAll(ISqlRepoisitory sqlRepository, IBindService bindService)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
        }

        public IEnumerable<object> All(string Entity)
        {

            if (Entity == "Teams") return bindService.TeamBind(sqlRepository.GettAll<Team>());

            if (Entity == "Races") return bindService.RaceBind(sqlRepository.GettAll<Race>());

            if (Entity == "News") return bindService.NewsBind(sqlRepository.GettAll<News>());

            if (Entity == "Drivers") return bindService.DriverBind(sqlRepository.GettAll<Driver>());

            if (Entity == "Championships") return bindService.ChampionshipBind(sqlRepository.GettAll<Championship>());

            return null;
        }

        public ReadNewsViewModel NewsDeatils(string newsId)
        {
            var context = new SqlDBContext();

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
