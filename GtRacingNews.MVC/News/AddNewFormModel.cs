using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.News
{
    public class AddNewFormModel
    {

        [Required]
        [MaxLength(100)]
        public string Heading { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
