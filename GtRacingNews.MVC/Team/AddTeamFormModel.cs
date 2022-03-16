using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Team
{
    public class AddTeamFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string CarModel { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        public string ChampionshipName { get; set; }
        public ICollection<Data.DataModels.Championship> Championships { get; set; }
    }
}
