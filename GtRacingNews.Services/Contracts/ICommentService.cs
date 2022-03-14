namespace GtRacingNews.Services.Contracts
{
    public interface ICommentService
    {
        void AddNewComment(string Description, int newsId, string UserName);
    }
}
