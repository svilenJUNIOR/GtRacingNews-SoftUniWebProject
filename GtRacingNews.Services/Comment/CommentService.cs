namespace GtRacingNews.Services.Comment
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
