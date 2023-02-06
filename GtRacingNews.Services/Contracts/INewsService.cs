using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Contracts
{
    public interface INewsService
    {

        //add
        public async Task AddNews(string heading, string description, string pictureUrl, bool isModerator, string userId)
        {
            var news = new News(heading, description, pictureUrl);
            if (isModerator) news.UserId = userId;
            await sqlRepository.AddAsync<News>((News)news);
        }
        //edit
        public void EditNews(string Id, AddNewFormModel data)
        {
            var news = this.sqlRepository.FindById<News>(Id);

            news.PictureUrl = data.PictureUrl;
            news.Description = data.Description;
            news.Heading = data.Heading;

            this.sqlRepository.SaveChangesAsync();
        }

        //bind
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
        //get

        public ReadNewsViewModel NewsDetails(string Id)
            => this.bindService.NewsDetails(Id);
    }
}
