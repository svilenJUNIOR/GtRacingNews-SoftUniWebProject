using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Service
{
    public class ReturnAll : IReturnAll
    {
        private readonly ISqlRepository sqlRepository;
        private readonly IBindService bindService;
        public ReturnAll(ISqlRepository sqlRepository, IBindService bindService)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
        }
        public IEnumerable<object> All(string Entity)
        {

            if (Entity == "Teams") return this.bindService.TeamBind(sqlRepository.GettAll<Team>());

            if (Entity == "Races") return this.bindService.RaceBind(sqlRepository.GettAll<Race>());

            if (Entity == "News") return this.bindService.NewsBind(sqlRepository.GettAll<News>());

            if (Entity == "Drivers") return this.bindService.DriverBind(sqlRepository.GettAll<Driver>());

            if (Entity == "Championships") return this.bindService.ChampionshipBind(sqlRepository.GettAll<Championship>());

            return null;
        }
        public ReadNewsViewModel NewsDeatils(string newsId)
        {

            var news = sqlRepository.GettAll<News>().Where(x => x.Id == newsId)
                .Select(n => new ReadNewsViewModel
                {
                    NewsId = n.Id,
                    Description = n.Description,
                    Comments = sqlRepository.GettAll<Comment>().Where(x => x.NewsId == n.Id).ToList()
                }).FirstOrDefault();

            return news;
        }
}
}
