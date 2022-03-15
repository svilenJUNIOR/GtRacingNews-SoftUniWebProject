namespace GtRacingNews.Services.Contracts
{
    public interface ICommentService
    {
        Task AddNewComment(string Description, int newsId, string UserName);
    }
}
