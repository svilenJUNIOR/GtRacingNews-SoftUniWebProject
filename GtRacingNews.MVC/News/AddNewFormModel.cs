using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.News
{
    public class AddNewFormModel
    {

        [Required]
        [MaxLength(100, ErrorMessage = "The heading must be less than 100 symbols!")]
        public string Heading { get; set; }

        [Required]
        [MaxLength(10000, ErrorMessage = "The description must be less than 10000 symbols!")]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
