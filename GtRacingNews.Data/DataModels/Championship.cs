using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Championship
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        public string LogoUrl { get; set; }
    }
}
