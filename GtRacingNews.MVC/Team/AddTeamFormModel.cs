using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Team
{
    public class AddTeamFormModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The name must be less than 50 symbols!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The car model must be less than 30 symbols!")]
        public string CarModel { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        public string ChampionshipName { get; set; }
        public ICollection<Data.DataModels.SqlModels.Championship> Championships { get; set; } = new List<Data.DataModels.SqlModels.Championship>();
    }
}
