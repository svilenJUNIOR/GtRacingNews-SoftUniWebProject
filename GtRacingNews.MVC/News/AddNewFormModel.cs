using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.News
{
    public class AddNewFormModel
    {
        [MaxLength(100)]
        public string Heading { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
    }
}
