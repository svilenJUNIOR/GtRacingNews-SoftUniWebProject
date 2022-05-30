using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Driver
{
    public class AddNewDriverFormModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The name must be less than 30 symbols!")]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "The cup name must be less than 10 symbols!")]
        public string Cup { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public string TeamName { get; set; }
        public ICollection<Data.DataModels.SqlModels.Team> Teams { get; set; } = new List<Data.DataModels.SqlModels.Team>();
    }
}
