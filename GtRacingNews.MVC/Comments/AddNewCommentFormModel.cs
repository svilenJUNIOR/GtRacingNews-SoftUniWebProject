using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Comments
{
    public class AddNewCommentFormModel
    {
        [Required]
        [DisplayName("Submit your comment")]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
