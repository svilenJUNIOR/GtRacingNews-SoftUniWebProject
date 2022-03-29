using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Race
{
    public class AddNewRaceFormModel : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The name must be less than 50 symbols!")]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
