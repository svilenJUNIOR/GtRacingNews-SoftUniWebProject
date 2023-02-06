using GtRacingNews.Data.DataModels.SqlModels;

namespace GtRacingNews.Services.Comments
{
    public class CommentService : ICommentService
    {
        public async Task AddNewComment(string Description, string newsId, string UserName)
        {
            var comment = new Comment(Description, newsId, UserName);
            await sqlRepository.AddAsync<Comment>((Comment)comment);
        }
    }
}
