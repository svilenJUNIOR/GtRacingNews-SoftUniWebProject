using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Championship
{
    public class AddNewChampionshipFormModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "The name must be less than 50 symbols!")]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }
    }
}
