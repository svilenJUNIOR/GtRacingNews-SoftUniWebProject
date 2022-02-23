using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
