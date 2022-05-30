using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class Team
    {
        public Team(string name, string carModel, string logoUrl)
        {
            this.Name = name;
            this.CarModel = carModel;
            this.LogoUrl = logoUrl;
        }
        
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

        [MaxLength(30)]
        public string CarModel { get; set; }

        [Required]
        public string LogoUrl { get; set; }
    }
}
