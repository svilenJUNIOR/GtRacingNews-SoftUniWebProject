//using GtRacingNews.Data.DataModels;
//using GtRacingNews.Data.DBContext;
//using GtRacingNews.Services.Contracts;
//using GtRacingNews.ViewModels.News;

//namespace GtRacingNews.Services.Service
//{
//    public class ReturnAll : IReturnAll
//    {
//        private readonly IRepository repository;
//        private readonly IBindService bindService;
//        public ReturnAll(IRepository repository, IBindService bindService)
//        {
//            this.repository = repository;
//            this.bindService = bindService;
//        }

//        public IEnumerable<object> All(string Entity)
//        {

//            if (Entity == "Teams")  return bindService.TeamBind(repository.GettAll<Team>());

//            if (Entity == "Races") return bindService.RaceBind(repository.GettAll<Race>());
             
//            if (Entity == "News") return bindService.NewsBind(repository.GettAll<News>());

//            if (Entity == "Drivers") return bindService.DriverBind(repository.GettAll<Driver>());

//            if (Entity == "Championships") return bindService.ChampionshipBind(repository.GettAll<Championship>());

//            return null;
//        }

//        public ReadNewsViewModel NewsDeatils(int newsId)
//        {
//            var context = new SqlDBContext();

//            var news = context.News.Where(x => x.Id == newsId)
//                .Select(n => new ReadNewsViewModel
//                {
//                    NewsId = n.Id,
//                    Description = n.Description,
//                    Comments = context.Comments.Where(x => x.NewsId == n.Id).ToList()
//                }).FirstOrDefault();

//            return news;
//        }
//    }
//}
