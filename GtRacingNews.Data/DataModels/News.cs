﻿using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class News
    {
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
    }
}
