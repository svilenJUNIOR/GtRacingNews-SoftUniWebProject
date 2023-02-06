using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Repositories;

namespace GtRacingNews.Services.Contracts
{
    public interface ICommentService
    {
        //add
        public async Task AddNewComment(string Description, string newsId, string UserName)
        {
            var comment = new Comment(Description, newsId, UserName);
            await sqlRepository.AddAsync<Comment>((Comment)comment);
        }
    }
}
