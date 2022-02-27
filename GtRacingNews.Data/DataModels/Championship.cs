using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Championship
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TeamId { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
