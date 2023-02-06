using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;

namespace GtRacingNews.Services.Comments
{
    public class CommentService : ICommentService
    {
        private ISqlRepository sqlRepository;
        public CommentService(ISqlRepository sqlRepository) 
            => this.sqlRepository = sqlRepository;
        public async Task AddNewComment(string Description, string newsId, string UserName)
        {
            var comment = new Comment(Description, newsId, UserName);
            await sqlRepository.AddAsync<Comment>((Comment)comment);
        }
    }
}
