using GtRacingNews.Data.DataModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace GtRacingNews.Services.Service
{
    public class MongoSeeder : IMongoSeeder
    {
        private readonly IMongoRepository mongoRepository;
        public MongoSeeder(IMongoRepository mongoRepository) 
            => this.mongoRepository = mongoRepository;

        public void SeedDriver()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Drivers");

            var driversJson = File.ReadAllText(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Driver.json");

            var drivers = JsonConvert.DeserializeObject<List<Driver>>(driversJson);
            
            foreach (var driver in drivers)
            {
                var id = new BsonObjectId(new ObjectId(driver.Id)).ToString();
                driver.Id = id;
                var bson = driver.ToBsonDocument();
                var document = BsonDocument.Create(bson);
                
                collection.InsertOneAsync(document);
            }
        }

        public void SeedChampionship()
        {
            throw new NotImplementedException();
        }

        public void SeedComments()
        {
            throw new NotImplementedException();
        }

        public void SeedNews()
        {
            throw new NotImplementedException();
        }

        public void SeedProfiles()
        {
            throw new NotImplementedException();
        }

        public void SeedRaces()
        {
            throw new NotImplementedException();
        }

        public void SeedTeams()
        {
            throw new NotImplementedException();
        }
    }
}
