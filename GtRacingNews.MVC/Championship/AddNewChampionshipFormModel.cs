using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Championship
{
    public class AddNewChampionshipFormModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }
    }
}
