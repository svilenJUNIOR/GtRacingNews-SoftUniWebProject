using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class Championship
    {
        public Championship(string name, string logoUrl)
        {
            this.Name = name;
            this.LogoUrl = logoUrl;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        public string LogoUrl { get; set; }
    }
}
