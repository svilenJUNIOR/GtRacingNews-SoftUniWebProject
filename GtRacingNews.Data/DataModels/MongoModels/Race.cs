using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class Race
    {
        public Race(string Name, string Date)
        {
            this.Name = Name;
            this.Date = Date;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
