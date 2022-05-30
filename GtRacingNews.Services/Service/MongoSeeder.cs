using GtRacingNews.Data.DataModels.MongoModels;
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

        public async Task SeedDriver()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Drivers");

            var driversJson = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Driver.json");

            var drivers = JsonConvert.DeserializeObject<List<Driver>>(driversJson);
            
            foreach (var driver in drivers)
            {
                var bson = driver.ToBsonDocument();
                var document = BsonDocument.Create(bson);
                
                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedChampionship()
        {
            throw new NotImplementedException();
        }

        public async Task SeedComments()
        {
            throw new NotImplementedException();
        }

        public async Task SeedNews()
        {
            throw new NotImplementedException();
        }

        public async Task SeedProfiles()
        {
            throw new NotImplementedException();
        }

        public async Task SeedRaces()
        {
            throw new NotImplementedException();
        }

        public async Task SeedTeams()
        {
            throw new NotImplementedException();
        }
    }
}
