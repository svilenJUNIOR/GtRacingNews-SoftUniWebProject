namespace GtRacingNews.Services.Comments
{
    public interface ICommentService
    {
        public Task AddNewComment(string Description, string newsId, string UserName);
    }
}
