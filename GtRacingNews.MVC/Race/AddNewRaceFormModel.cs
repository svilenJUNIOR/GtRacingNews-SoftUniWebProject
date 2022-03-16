using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Race
{
    public class AddNewRaceFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
