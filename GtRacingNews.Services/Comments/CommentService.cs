using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Comments
{
    public class CommentService : ICommentService
    {
        private ISqlRepository sqlRepository;
        private IGuard guard;
        public CommentService(ISqlRepository sqlRepository, IGuard guard)
        {
            this.sqlRepository = sqlRepository;
            this.guard = guard;
        }

        public async Task AddNewComment(AddNewCommentFormModel model, ModelStateDictionary modelState,string newsId, string userName)
        {
            IEnumerable<Exception> NullErrors = this.guard.AgainstNull(model.Description);
            IEnumerable<Exception> ModelStateErrorsErrors = this.guard.CheckModelState(modelState);

            ICollection<Exception> Errors = this.guard.CollectErrors(NullErrors, ModelStateErrorsErrors);

            var comment = new Comment(model.Description, newsId, userName);

            await sqlRepository.AddAsync<Comment>((Comment)comment);
        }
    }
}
