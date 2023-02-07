using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.News;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Newss
{
    public class NewsService : INewsService
    {
        private ISqlRepository sqlRepository;
        private IGuard guard;
        public NewsService(ISqlRepository sqlRepository, IGuard guard)
        {
            this.sqlRepository = sqlRepository;
            this.guard = guard;
        }

        public async Task AddNews(AddNewFormModel model, ModelStateDictionary modelState, bool isModerator, string userId)
        {
            ICollection<Exception> Errors = this.guard.CheckModelState(modelState);

            if (Errors.Any()) this.guard.ThrowErrors(Errors);

            var doesExist = this.sqlRepository.GettAll<News>().Any(x => x.Heading == model.Heading);
            if (doesExist)
            {
                Errors.Clear();
                Errors.Add(new ArgumentException(Messages.ExistingNews));
                this.guard.ThrowErrors(Errors);
            }

            var news = new News(model.PictureUrl, model.Description, model.Heading);

            if (isModerator) news.UserId = userId;

            await sqlRepository.AddAsync<News>((News)news);
        }
      
        public void EditNews(string Id, AddNewFormModel data)
        {
            var news = this.sqlRepository.FindById<News>(Id);

            news.PictureUrl = data.PictureUrl;
            news.Description = data.Description;
            news.Heading = data.Heading;

            this.sqlRepository.SaveChangesAsync();
        }
       
        public ICollection<ShowAllNewsViewModel> NewsBind(ICollection<News> newsToBind)
        {
            var bindedNews = newsToBind.Select(x => new ShowAllNewsViewModel
            {
                Heading = x.Heading,
                Id = x.Id,
                ImgUrl = x.PictureUrl
            }).ToList();

            return bindedNews;
        }
        
        public ReadNewsViewModel NewsDetails(string newsId)
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

        public ICollection<ShowGuestNews> GuestNewsBind(ICollection<News> newsToBind)
        {
            var bindedNews = newsToBind
              .Select(x => new ShowGuestNews
              {
                  Id = x.Id,
                  Heading = x.Heading,
                  Description = x.Description
              }).Take(5).ToList();

            return bindedNews;
        }
        
        public ICollection<ShowAllNewsViewModel> GetAll()
         => this.NewsBind(sqlRepository.GettAll<News>());
    }
}
