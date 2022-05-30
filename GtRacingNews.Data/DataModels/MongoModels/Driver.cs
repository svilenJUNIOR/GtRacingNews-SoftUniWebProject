using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class Driver
    {
        public Driver(string name, int age, string cup, string imageUrl)
        {
            this.Name = name;
            this.Age = age;
            this.Cup = cup;
            this.ImageUrl = imageUrl;
        }

        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

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
    }
}
