using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class News
    {
        public News(string heading, string description, string pictureUrl)
        {
            this.Heading = heading;
            this.Description = description;
            this.PictureUrl = pictureUrl;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

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
