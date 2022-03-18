using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Comments
{
    public class AddNewCommentFormModel
    {
        [Required]
        [DisplayName("Submit your comment")]
        [MaxLength(100, ErrorMessage = "The description must be less than 100 symbols!")]
        public string Description { get; set; }
    }
}
