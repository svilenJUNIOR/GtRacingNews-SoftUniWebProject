using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels.MongoModels
{
    public class Profile
    {
        public Profile(int age, string profileType,string Address, string profilePicture)
        {
            this.Age = age;
            this.ProfileType = profileType;
            this.Address = Address;
            this.ProfilePicture = profilePicture;
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProfilePicture { get; set; }
        public int Age { get; set; }
        public string ProfileType { get; set; }
        public string Address { get; set; }
    }
}
