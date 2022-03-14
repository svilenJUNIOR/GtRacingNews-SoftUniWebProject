using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

        [MaxLength(30)]
        public string CarModel { get; set; }
        public string LogoUrl { get; set; }
        public int ChampionshipId { get; set; }
    }
}
