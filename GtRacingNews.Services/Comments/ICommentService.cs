using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Comments
{
    public interface ICommentService
    {
        Task AddNewComment(AddNewCommentFormModel model, ModelStateDictionary modelState, string newsId, string UserName);
    }
}
