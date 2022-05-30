using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class Comment
    {
        public Comment(string description,string userName)
        {
            this.Description = description;
            this.UserName = userName;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
