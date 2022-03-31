﻿using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class News
    {
        public News(string heading, string description, string pictureUrl)
        {
            this.Heading = heading;
            this.Description = description;
            this.PictureUrl = pictureUrl;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Heading { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public int? ProfileId { get; set; }

    }
}
