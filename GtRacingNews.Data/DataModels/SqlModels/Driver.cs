using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.SqlModels
{
    public class Driver
    {
        public Driver(string name, int age, string cup, string imageUrl, string? teamId)
        {
            this.Name = name;
            this.Age = age;
            this.Cup = cup;
            this.ImageUrl = imageUrl;
            this.TeamId = teamId;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

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

        public string? TeamId { get; set; }
        public string? UserId { get; set; }

    }
}
