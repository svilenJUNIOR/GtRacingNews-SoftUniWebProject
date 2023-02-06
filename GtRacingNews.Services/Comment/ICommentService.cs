namespace GtRacingNews.Services.Comment
{
    public interface ICommentService
    {
        public Task AddNewComment(string Description, string newsId, string UserName);
    }
}
