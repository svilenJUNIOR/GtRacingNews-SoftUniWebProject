using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
