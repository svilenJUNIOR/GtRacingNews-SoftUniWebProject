using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.SqlModels
{
    public class Team
    {
        public Team(string name, string carModel, string logoUrl, string? ChampionshipId)
        {
            this.Name = name;
            this.CarModel = carModel;
            this.LogoUrl = logoUrl;
            this.ChampionshipId = ChampionshipId;
        }
        
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

        [MaxLength(30)]
        public string CarModel { get; set; }

        [Required]
        public string LogoUrl { get; set; }
        public string? ChampionshipId { get; set; }
        public string? UserId { get; set; }
    }
}
