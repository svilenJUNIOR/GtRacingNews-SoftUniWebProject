using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Driver
{
    public class AddNewDriverFormModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(10)]
        public string Cup { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public string TeamName { get; set; }
        public ICollection<Data.DataModels.Team> Teams { get; set; } = new List<Data.DataModels.Team>();
    }
}
