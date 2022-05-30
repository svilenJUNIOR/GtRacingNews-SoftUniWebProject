using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.SqlModels
{
    public class Comment
    {
        public Comment(string description, string? newsId, string userName)
        {
            this.Description = description;
            this.NewsId = newsId;
            this.UserName = userName;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public string? NewsId { get; set; }
        public string UserName { get; set; }
    }
}
