using System;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Driver
    {
        public Driver(string name, int age, string cup, string imageUrl, int? teamId)
        {
            this.Name = name;
            this.Age = age;
            this.Cup = cup;
            this.ImageUrl = imageUrl;
            this.TeamId = teamId;
        }
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

        public int? TeamId { get; set; }
        public int? ProfileId { get; set; }

    }
}
