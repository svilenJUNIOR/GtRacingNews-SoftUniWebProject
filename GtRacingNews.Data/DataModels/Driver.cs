using System;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Driver
    {
        public int Id { get; set; }

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

        public int TeamId { get; set; }
    }
}
