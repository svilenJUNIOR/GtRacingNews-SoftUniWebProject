using System.ComponentModel;

namespace GtRacingNews.ViewModels.Comments
{
    public class AddNewCommentFormModel
    {
        [DisplayName("Submit your comment")]
        public string Description { get; set; }
    }
}
