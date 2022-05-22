using GtRacingNews.Data.DataModels;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Service
{
    public class ReturnAll : IReturnAll
    {
        private readonly IEngine engine;
        public UserService(IEngine engine) => this.engine = engine;

        public IEnumerable<object> All(string Entity)
        {

            if (Entity == "Teams") return this.engine.bindService.TeamBind(engine.sqlRepository.GettAll<Team>());
            
            if (Entity == "Races") return this.engine.bindService.RaceBind(engine.sqlRepository.GettAll<Race>());
            
            if (Entity == "News") return this.engine.bindService.NewsBind(engine.sqlRepository.GettAll<News>());
           
            if (Entity == "Drivers") return this.engine.bindService.DriverBind(engine.sqlRepository.GettAll<Driver>());
           
            if (Entity == "Championships") return this.engine.bindService.ChampionshipBind(engine.sqlRepository.GettAll<Championship>());

            return null;
        }
        public ReadNewsViewModel NewsDeatils(string newsId)
        {

            var news = engine.sqlRepository.GettAll<News>().Where(x => x.Id == newsId)
                .Select(n => new ReadNewsViewModel
                {
                    NewsId = n.Id,
                    Description = n.Description,
                    Comments = engine.sqlRepository.GettAll<Comment>().Where(x => x.NewsId == n.Id).ToList()
                }).FirstOrDefault();

            return news;
        }
    }
}
